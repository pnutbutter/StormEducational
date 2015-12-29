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