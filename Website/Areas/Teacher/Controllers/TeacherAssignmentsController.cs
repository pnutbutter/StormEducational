using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Assign(int id, string Message)
        {
            TeacherAssignmentsAssign data = new TeacherAssignmentsAssign();
            try
            {
                Group item = db.Groups.Find(id);
                if (item.GroupTypeId == 6 && (item.OwnerUserId == this.GetCurrentUser().UserId || User.IsInRole("Admin") || User.IsInRole("DistrictAdmin") || User.IsInRole("SchoolAdmin")))
                {
                    data.ItemList = db.TeacherStudentViews.Where(t => t.TeacherUserId == this.GetCurrentUser().UserId).ToList();
                    data.Message = Message;
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