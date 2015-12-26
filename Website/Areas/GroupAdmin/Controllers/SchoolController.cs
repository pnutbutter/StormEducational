using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.GroupAdmin.Models.SchoolData;

namespace Website.Areas.GroupAdmin.Controllers
{
    public class SchoolController : Controller  
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Administration/Group
        public ActionResult Index(string Message)
        {
            SchoolIndex data = new SchoolIndex();

            data.ItemList = db.GroupViews.Where(g => g.GroupTypeId == 2).ToList();
            data.Message = Message;

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SchoolCreate data = new SchoolCreate();
            ViewBag.GroupTypeId = new SelectList(db.GroupTypes, "GroupTypeId", "GroupName");
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolCreate data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                Group item = new Group();
                item.GroupName = data.GroupName;
                // set all groups on this screen to active.  Admins at this level can't inactivate or activate schools
                item.IsActive = true;
                // Hard code to only allow user to add group types of school
                item.GroupTypeId = 2;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;
                item.CreateBy = this.User.Identity.Name;
                item.CreateDate = DateTime.Now;

                db.Groups.Add(item);
                db.SaveChanges();


                /// Gary TODO: sent email to school administrator
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.GroupName + " Saved" });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SchoolEdit data = new SchoolEdit();

            Group item = db.Groups.Find(id);
            data.GroupName = item.GroupName;
            ViewBag.GroupTypeId = new SelectList(db.GroupTypes, "GroupTypeId", "GroupName", item.GroupTypeId);
            data.GroupId = item.GroupId;
            return View(data);
        }

        [HttpPost]
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
    }
}