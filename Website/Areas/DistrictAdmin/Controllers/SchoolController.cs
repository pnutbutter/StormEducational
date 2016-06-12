using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.DistrictAdmin.Models.SchoolData;
using Website.Controllers;

namespace Website.Areas.DistrictAdmin.Controllers
{
    public class SchoolController : BaseController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DistrictAdmin/Group
        [Authorize]
        public ActionResult Index(string Message)
        {

            int userid = this.GetCurrentUser().UserId;
            
            SchoolIndex data = new SchoolIndex(); 

            data.DistrictId = db.UserGroupViews.Where(u => u.GroupTypeId == 1 && u.UserId == userid).FirstOrDefault().GroupId;
            data.ItemList = db.GroupViews.Where(g => g.IsActive == true && g.GroupTypeId == 2 && g.OwnerUserId != null && g.OwnerUserId.Value == userid && g.ParentGroupId == data.DistrictId).ToList();
            data.Message = Message;

            return View(data);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create(int Id)
        {
            SchoolCreate data = new SchoolCreate();
            data.DistrictId = Id;
            return View(data);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolCreate data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                //ensure that user has the access to add a school for this district.

                Group item = new Group();
                item.GroupName = data.GroupName;
                item.OwnerUserId = this.GetCurrentUser().UserId;
                item.IsActive = true;
                // Hard code to only allow user to add group types of School
                item.GroupTypeId = 2;
                
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;
                item.CreateBy = this.User.Identity.Name;
                item.CreateDate = DateTime.Now;

                db.Groups.Add(item);
                db.SaveChanges();

                //Add group relation
                GroupRelation groupRelation = new GroupRelation();

                groupRelation.ChildGroupId = item.GroupId;
                groupRelation.ParentGroupId = data.DistrictId;
                groupRelation.IsActive = true;
                groupRelation.ChangeBy = this.User.Identity.Name;
                groupRelation.ChangeDate = DateTime.Now;
                groupRelation.CreateBy = this.User.Identity.Name;
                groupRelation.CreateDate = DateTime.Now;

                db.GroupRelations.Add(groupRelation);
                db.SaveChanges();

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
            SchoolEdit data = new SchoolEdit();

            Group item = db.Groups.Find(id);
            data.GroupName = item.GroupName;
            data.GroupId = item.GroupId;
            return View(data);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SchoolEdit data)
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
            SchoolDelete data = new SchoolDelete();
            try
            {
                Group item = db.Groups.Find(id);
                if (item.GroupTypeId == 2 && (item.OwnerUserId == this.GetCurrentUser().UserId || User.IsInRole("Admin") || User.IsInRole("DistrictAdmin") || User.IsInRole("SchoolAdmin")))
                {
                    data.GroupName = item.GroupName;
                    data.GroupId = item.GroupId;
                }
                else
                {
                    throw new ArgumentException("You do not have permissions to delete this school");
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
        public ActionResult ConfirmDelete(SchoolDelete data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                Group item = db.Groups.Find(data.GroupId);
                if (item.GroupTypeId == 2 && (item.OwnerUserId == this.GetCurrentUser().UserId || User.IsInRole("Admin") || User.IsInRole("DistrictAdmin") || User.IsInRole("SchoolAdmin")))
                {
                    //set group name for return message
                    data.GroupName = item.GroupName;

                    //soft delete group
                    item.IsActive = false;
                    item.ChangeBy = this.User.Identity.Name;
                    item.ChangeDate = DateTime.Now;

                    db.Entry<Group>(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("You do not have permissions to delete this school");
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.GroupName + " School Deleted" });
        }


    }
}