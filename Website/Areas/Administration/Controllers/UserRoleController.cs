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

            return View(data);
        }
    }
}