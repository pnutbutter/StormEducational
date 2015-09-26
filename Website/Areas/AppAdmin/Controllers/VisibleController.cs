using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.AppAdmin.Models.VisibleData;

namespace Website.Areas.AppAdmin.Controllers
{
    public class VisibleController : Controller
    {
        // GET: AppAdmin/Visible
        public ActionResult Index()
        {
            VisibleIndex data = new VisibleIndex();
            data.AppName = "Storm Educational";
            return View(data);
        }

        public ActionResult Create()
        {
            VisibleCreate data = new VisibleCreate();
            return View(data);
        }
    }
}