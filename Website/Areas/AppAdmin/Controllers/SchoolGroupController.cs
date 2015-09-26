using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.AppAdmin.Models.SchoolGroupData;

namespace Website.Areas.AppAdmin.Controllers
{
    public class SchoolGroupController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: AppAdmin/SchoolGroup
        public ActionResult Create()
        {
            SchoolGroupCreate data = new SchoolGroupCreate();
            ViewBag.GroupTypeId = new SelectList(db.GroupTypes, "GroupTypeId", "GroupName");
            return View(data);
        }
    }
}