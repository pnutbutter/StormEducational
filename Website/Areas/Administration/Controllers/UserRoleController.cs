using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.Administration.Models.UserRoleData;

namespace Website.Areas.Administration.Controllers
{
    public class UserRoleController : Controller
    {

        private DatabaseContext db = new DatabaseContext();

        // GET: Administration/UserRole
        public ActionResult Index(string Message, decimal id)
        {
            UserRoleIndex data = new UserRoleIndex();

            data.ItemList = db.UserRoleViews.Where(u => u.UserId == id).ToList();
            data.Message = Message;
            data.UserId = id;

            return View(data);
        }

        [HttpGet]
        public ActionResult Create(decimal UserId)
        {
            UserRoleCreate data = new UserRoleCreate();
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRoleCreate data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                UserRole item = new UserRole();

                item.RoleId = data.RoleId;
                item.UserId = data.UserId;
                item.IsActive = true;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;
                item.CreateBy = this.User.Identity.Name;
                item.CreateDate = DateTime.Now;

                db.UserRoles.Add(item);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { message = "New Role Saved", id = data.UserId });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserRoleEdit data = new UserRoleEdit();

            UserRole item = db.UserRoles.Find(id);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", item.RoleId);
            data.IsActive = item.IsActive;
            data.UserId = item.UserId;
            data.UserRoleId = item.UserRoleId;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserRoleEdit data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                UserRole item = db.UserRoles.Find(data.UserRoleId);
                item.RoleId = data.RoleId;
                item.IsActive = data.IsActive;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<UserRole>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = "Edits to User Role Saved", id = data.UserId });
        }
    }
}