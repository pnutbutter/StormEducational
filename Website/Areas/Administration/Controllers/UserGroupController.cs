using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.Administration.Models.UserGroupData;

namespace Website.Areas.Administration.Controllers
{
    public class UserGroupController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Administration/UserGroup
        public ActionResult Index(string Message, decimal id)
        {
            UserGroupIndex data = new UserGroupIndex();

            data.ItemList = db.UserGroupViews.Where(u => u.UserId == id).ToList();
            data.Message = Message;
            data.UserId = id;

            return View(data);
        }

        [HttpGet]
        public ActionResult Create(decimal UserId)
        {
            UserGroupCreate data = new UserGroupCreate();
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName");
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserGroupCreate data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                UserGroup item = new UserGroup();

                item.GroupId = data.GroupId;
                item.UserId = data.UserId;
                item.IsActive = true;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;
                item.CreateBy = this.User.Identity.Name;
                item.CreateDate = DateTime.Now;

                db.UserGroups.Add(item);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { message = "New User Group Saved", id = data.UserId });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserGroupEdit data = new UserGroupEdit();

            UserGroup item = db.UserGroups.Find(id);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", item.GroupId);
            data.IsActive = item.IsActive;
            data.UserId = item.UserId;
            data.UserGroupId = item.UserGroupId;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserGroupEdit data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                UserGroup item = db.UserGroups.Find(data.UserGroupId);
                item.GroupId = data.GroupId;
                item.IsActive = data.IsActive;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<UserGroup>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = "Edits to User Group Saved", id = data.UserId });
        }
    }
}