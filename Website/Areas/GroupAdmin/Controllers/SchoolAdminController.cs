using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.GroupAdmin.Models.SchoolAdminData;

namespace Website.Areas.GroupAdmin.Controllers
{
    public class SchoolAdminController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Administration/Group
        public ActionResult Index(string Message, decimal id)
        {
            SchoolAdminIndex data = new SchoolAdminIndex();

            // Role Id for School Admin is 2
            data.ItemList = db.UserRoleGroupViews.Where(u => u.RoleId == 2 && u.GroupId == id).ToList();

            data.Message = Message;

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SchoolAdminCreate data = new SchoolAdminCreate();
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameFull");
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolAdminCreate data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                //Relate user to group via UserGroup Table
                UserGroup userGroupItem = new UserGroup();
                userGroupItem.UserId = data.UserId;
                userGroupItem.GroupId = data.GroupId;
                userGroupItem.IsActive = true;
                userGroupItem.ChangeBy = this.User.Identity.Name;
                userGroupItem.ChangeDate = DateTime.Now;
                userGroupItem.CreateBy = this.User.Identity.Name;
                userGroupItem.CreateDate = DateTime.Now;

                db.UserGroups.Add(userGroupItem);
                db.SaveChanges();

                //Relate User to role via UserRole table
                UserRole userRoleItem = new UserRole();
                userRoleItem.UserId = data.UserId;
                userRoleItem.RoleId = data.RoleId;
                userRoleItem.IsActive = true;
                userRoleItem.ChangeBy = this.User.Identity.Name;
                userRoleItem.ChangeDate = DateTime.Now;
                userRoleItem.CreateBy = this.User.Identity.Name;
                userRoleItem.CreateDate = DateTime.Now;

                db.UserRoles.Add(userRoleItem);
                db.SaveChanges();

            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = "Saved as School Administrator" });
        }


        [HttpGet]
        public ActionResult ConfirmDelete(int UserRoleId, int GroupId)
        {
            SchoolAdminConfirmDelete data = new SchoolAdminConfirmDelete();

            data.UserRoleId = UserRoleId;
            data.GroupId = GroupId;

            UserRole userRole = db.UserRoles.Find(UserRoleId);
                   
            User item = db.Users.Find(userRole.UserId);
            data.FirstName = item.FirstName;
            data.LastName = item.LastName;

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(SchoolAdminConfirmDelete data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                UserRole item = db.UserRoles.Find(data.UserRoleId);
                item.IsActive = false;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<UserRole>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { id = data.GroupId, Message = " School admin role for " + data.FirstName + data.LastName + "  has been inactivated" });
        }
    }
}