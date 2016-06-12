using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.Teacher.Models.TeacherAssignmentsData;
using Website.Controllers;

namespace Website.Areas.Teacher.Controllers
{
    public class TeacherAssignmentsController : BaseController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Teacher/Assignments
        public ActionResult Index(string Message)
        {
            TeacherAssignmentsIndex data = new TeacherAssignmentsIndex();

            //TODO: filter down to ones only assigned by current teacher
            UserView currentUser = this.GetCurrentUser();
            data.ItemList = db.Assignments.Where(a => a.UserId == currentUser.UserId && a.IsActive==true).ToList();

            data.Message = Message;

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            TeacherAssignmentsCreate data = new TeacherAssignmentsCreate();
            ViewBag.AssignmentTypeId = new SelectList(db.AssignmentTypes, "AssignmentTypeId", "AssignmentTypeTitle");
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherAssignmentsCreate data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                Assignment item = new Assignment();
                item.AssignmentDescription = data.AssignmentDescription;
                item.AssignmentSpanishDescription = data.AssignmentSpanishDescription;
                item.AssignmentSpanishTitle = data.AssignmentSpanishTitle;
                item.AssignmentTitle = data.AssignmentTitle;
                item.AssignmentTypeId = data.AssignmentTypeId;
                item.IsActive = true;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;
                item.CreateBy = this.User.Identity.Name;
                item.CreateDate = DateTime.Now;
                item.UserId = this.GetCurrentUser().UserId;

                db.Assignments.Add(item);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.AssignmentTitle + " Saved" });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            TeacherAssignmentsEdit data = new TeacherAssignmentsEdit();

            Assignment item = db.Assignments.Find(id);
            data.AssignmentDescription = item.AssignmentDescription;
            data.AssignmentSpanishDescription = item.AssignmentSpanishDescription;
            data.AssignmentSpanishTitle = item.AssignmentSpanishTitle;
            data.AssignmentTitle = item.AssignmentTitle;
            data.AssignmentTypeId = item.AssignmentTypeId;
            ViewBag.AssignmentTypeId = new SelectList(db.AssignmentTypes, "AssignmentTypeId", "AssignmentTypeTitle");
            data.AssignmentId = item.AssignmentId;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherAssignmentsEdit data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                Assignment item = db.Assignments.Find(data.AssignmentId);
                item.AssignmentDescription = data.AssignmentDescription;
                item.AssignmentSpanishDescription = data.AssignmentSpanishDescription;
                item.AssignmentSpanishTitle = data.AssignmentSpanishTitle;
                item.AssignmentTitle = data.AssignmentTitle;
                item.AssignmentTypeId = data.AssignmentTypeId;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<Assignment>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.AssignmentTitle + " Edits Saved" });
        }

        [HttpGet]
        public ActionResult ConfirmDelete(int id)
        {
            TeacherAssignmentsDelete data = new TeacherAssignmentsDelete();
            Assignment item = db.Assignments.Find(id);
            data.AssignmentDescription = item.AssignmentDescription;
            data.AssignmentTitle = item.AssignmentTitle;
            data.AssignmentId = item.AssignmentId;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(TeacherAssignmentsDelete data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                Assignment item = db.Assignments.Find(data.AssignmentId);
                item.IsActive = false;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<Assignment>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.AssignmentTitle + " Assignment Inactivated" });
        }

        [HttpGet]
        public ActionResult Assign(int id, string Message, string Search, int? SchoolId)
        {
            TeacherAssignmentsAssign data = new TeacherAssignmentsAssign();
            try
            {
                Assignment item = db.Assignments.Find(id);
                UserView currentUser = this.GetCurrentUser();
                if (item.UserId == this.GetCurrentUser().UserId || User.IsInRole("Admin") || User.IsInRole("DistrictAdmin") || User.IsInRole("SchoolAdmin"))
                {
                    //get default school id to search by
                    var schoolQuery = from t1 in db.UserViews
                                      join t2 in db.UserGroupViews on t1.UserId equals t2.UserId
                                      where t2.UserId == currentUser.UserId && t2.GroupTypeId == 2
                                      select t2;
                    if (schoolQuery.Any())
                    {
                        List<UserGroupView> userGroupViewList = schoolQuery.ToList();
                        data.SchoolId = userGroupViewList.FirstOrDefault().GroupId;
                    }

                    //get assigned students
                    var assignedStudents = from t1 in db.UserViews
                                           join t2 in db.UserAssignments on t1.UserId equals t2.AssignedUserId
                                           where t2.AssignmentId == id && t2.IsActive==true
                                           select t1;
                    if (assignedStudents.Any())
                    {
                        data.AssignedList = assignedStudents.ToList();
                    }

                    data.Search = Search;

                    //populate lists
                    if (SchoolId.HasValue)
                    {
                        var query = from t1 in db.UserViews
                                    join t2 in db.UserGroupViews on t1.UserId equals t2.UserId
                                    where t2.GroupTypeId == 2 && t2.GroupId == SchoolId.Value
                                    select t1;
                        if (query.Any())
                        {
                            data.SearchList = query.ToList();
                        }
                        else
                        {
                            data.SearchList = new List<UserView>();
                        }
                        data.ItemList = new List<TeacherStudentView>();

                    }
                    else if (!string.IsNullOrWhiteSpace(Search))
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(TeacherAssignmentsAssign data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }
                Assignment item = db.Assignments.Find(data.Id);
                UserView currentUser = this.GetCurrentUser();

                //populate lists
                if ((item.UserId == currentUser.UserId || User.IsInRole("Admin") || User.IsInRole("DistrictAdmin") || User.IsInRole("SchoolAdmin")))
                {

                    data.ItemList = db.TeacherStudentViews.Where(t => t.TeacherUserId == currentUser.UserId).ToList();

                    //remove from class
                    if (data.Excluded != null && data.Excluded.Length > 0)
                    {

                        //soft delete class user relationship
                        for (int i = 0; i < data.Excluded.Length; i++)
                        {
                            int userid = data.Excluded[i];
                            UserAssignment userAssignment = db.UserAssignments.FirstOrDefault(u => u.AssignedUserId == userid && u.AssignmentId == data.Id);
                            userAssignment.IsActive = false;
                            userAssignment.ChangeBy = this.User.Identity.Name;
                            userAssignment.ChangeDate = DateTime.Now;
                            db.Entry<UserAssignment>(userAssignment).State = EntityState.Modified;
                        }
                    }
                    //Add Students
                    if (data.Included != null && data.Included.Length > 0)
                    {
                        for (int i = 0; i < data.Included.Length; i++)
                        {
                            int userid = data.Included[i];
                            UserAssignment userAssignment = db.UserAssignments.FirstOrDefault(u => u.AssignedUserId == userid && u.AssignmentId == data.Id);
                            if (userAssignment == null || userAssignment.UserAssignmentId == 0)
                            {
                                userAssignment = new UserAssignment();
                                userAssignment.AssignedUserId = data.Included[i];
                                userAssignment.AssignmentId = data.Id;
                                userAssignment.IsActive = true;
                                userAssignment.ChangeBy = this.User.Identity.Name;
                                userAssignment.ChangeDate = DateTime.Now;
                                userAssignment.CreateBy = this.User.Identity.Name;
                                userAssignment.CreateDate = DateTime.Now;
                                userAssignment.AssigningUserId = currentUser.UserId;
                                userAssignment.Grade = 0;
                                userAssignment.GradeDescription = "No Grade Yet";
                                db.UserAssignments.Add(userAssignment);
                            }
                            else
                            {
                                userAssignment.IsActive = true;
                                userAssignment.ChangeBy = this.User.Identity.Name;
                                userAssignment.ChangeDate = DateTime.Now;
                                db.Entry<UserAssignment>(userAssignment).State = EntityState.Modified;
                            }
                        }
                    }

                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("You do not have permissions to assign students to this group");
                }

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            if (data.Excluded != null && data.Excluded.Length > 0)
            {
                return RedirectToAction("Assign", new { Message = "Students removed from class", id = data.Id });
            }
            else
            {
                return RedirectToAction("Assign", new { Message = "Students added to class", id = data.Id });
            }
        }
    }
}