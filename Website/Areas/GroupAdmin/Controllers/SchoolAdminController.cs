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
    }
}