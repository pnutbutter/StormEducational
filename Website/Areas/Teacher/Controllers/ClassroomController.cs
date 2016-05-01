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
    public class ClassroomController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Administration/Group
        [Authorize]
        public ActionResult Index(string Message)
        {
            ClassroomIndex data = new ClassroomIndex();

            data.ItemList = db.GroupViews.Where(g => g.GroupTypeId == 2).ToList();
            data.Message = Message;

            return View(data);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            ClassroomCreate data = new ClassroomCreate();
            ViewBag.GroupTypeId = new SelectList(db.GroupTypes, "GroupTypeId", "GroupName");
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
                // set all groups on this screen to active.  Admins at this level can't inactivate or activate Classrooms
                item.IsActive = true;
                // Hard code to only allow user to add group types of Classroom
                item.GroupTypeId = 2;
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
            ViewBag.GroupTypeId = new SelectList(db.GroupTypes, "GroupTypeId", "GroupName", item.GroupTypeId);
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
    }
}