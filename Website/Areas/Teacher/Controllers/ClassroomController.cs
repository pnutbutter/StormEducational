using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.Teacher.Models.ClassroomData;
using Website.Controllers;

namespace Website.Areas.Teacher.Controllers
{
    public class ClassroomController : BaseController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Administration/Group
        [Authorize]
        public ActionResult Index(string Message)
        {
            ClassroomIndex data = new ClassroomIndex();
            int userid = this.GetCurrentUser().UserId;
            data.ItemList = db.GroupViews.Where(g => g.IsActive==true && g.GroupTypeId == 6 && g.OwnerUserId!=null && g.OwnerUserId.Value == userid).ToList();
            data.Message = Message;

            return View(data);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            ClassroomCreate data = new ClassroomCreate();
            return View(data);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassroomCreate data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                

                Group item = new Group();
                item.GroupName = data.GroupName;
                item.OwnerUserId = this.GetCurrentUser().UserId;
                // set all groups on this screen to active.  Admins at this level can't inactivate or activate Classrooms
                item.IsActive = true;
                // Hard code to only allow user to add group types of Classroom
                item.GroupTypeId = 6;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;
                item.CreateBy = this.User.Identity.Name;
                item.CreateDate = DateTime.Now;

                db.Groups.Add(item);
                db.SaveChanges();


                /// Gary TODO: sent email to Classroom administrator
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.GroupName + " Saved" });
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            ClassroomEdit data = new ClassroomEdit();

            Group item = db.Groups.Find(id);
            data.GroupName = item.GroupName;
            data.GroupId = item.GroupId;
            return View(data);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassroomEdit data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                Group item = db.Groups.Find(data.GroupId);
                item.GroupName = data.GroupName;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<Group>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.GroupName + " Edits Saved" });
        }

        [HttpGet]
        public ActionResult ConfirmDelete(int id)
        {
            ClassroomDelete data = new ClassroomDelete();
            try{
                Group item = db.Groups.Find(id);
                if(item.GroupTypeId == 6 && (item.OwnerUserId == this.GetCurrentUser().UserId || User.IsInRole("Admin") || User.IsInRole("DistrictAdmin") || User.IsInRole("SchoolAdmin")))
                {
                    data.GroupName = item.GroupName;
                    data.GroupId = item.GroupId;
                }else
                {
                    throw new ArgumentException("You do not have permissions to delete this group");
                }            
            }
            catch (Exception e)
            {
                throw;
            }
            
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(ClassroomDelete data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                Group item = db.Groups.Find(data.GroupId);
                if(item.GroupTypeId == 6 && (item.OwnerUserId == this.GetCurrentUser().UserId || User.IsInRole("Admin") || User.IsInRole("DistrictAdmin") || User.IsInRole("SchoolAdmin")))
                {
                    //set group name for return message
                    data.GroupName = item.GroupName;

                    //soft delete group
                    item.IsActive = false;
                    item.ChangeBy = this.User.Identity.Name;
                    item.ChangeDate = DateTime.Now;

                    db.Entry<Group>(item).State = EntityState.Modified;
                    db.SaveChanges();
                }else
                {
                    throw new ArgumentException("You do not have permissions to delete this group");
                }  
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.GroupName + " Classroom Deleted" });
        }

        [HttpGet]
        public ActionResult Assign(int id, string Message, string Search, int? SchoolId)
        {
            ClassroomAssign data = new ClassroomAssign();
            try
            {
                Group item = db.Groups.Find(id);
                UserView currentUser = this.GetCurrentUser();
                if (item.GroupTypeId == 6 && (item.OwnerUserId == currentUser.UserId || User.IsInRole("Admin") || User.IsInRole("DistrictAdmin") || User.IsInRole("SchoolAdmin")))
                {
                    if(SchoolId.HasValue)
                    {
                        var query  = from t1 in db.UserViews
                                        join t2 in db.UserGroupViews on t1.UserId equals t2.UserId
                                        where t2.GroupTypeId==2 && t2.GroupId==SchoolId.Value
                                        select t1;
                        if(query.Any())
                        {
                            data.SearchList = query.ToList();
                        }else
                        {
                            data.SearchList = new List<UserView>();
                        }
                        data.ItemList = new List<TeacherStudentView>();
                        
                    }else if(!string.IsNullOrWhiteSpace(Search))
                    {
                        data.SearchList = db.UserViews.Where(u => u.FirstName.ToLower().Contains(Search.ToLower()) || u.FirstName.ToLower().Contains(Search.ToLower())).ToList();
                        data.ItemList = new List<TeacherStudentView>();
                    }
                    else
                    {
                        data.ItemList = db.TeacherStudentViews.Where(t => t.TeacherUserId == currentUser.UserId).ToList();
                        data.SearchList = new List<UserView>();
                    }
                    
                    data.Message = Message;
                    data.Id = id;
                }
                else
                {
                    throw new ArgumentException("You do not have permissions to assign students to this group");
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return View(data);
        }
    }
}