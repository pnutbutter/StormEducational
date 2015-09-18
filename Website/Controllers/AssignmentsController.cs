using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models.AssignmentsData;

namespace Website.Controllers
{
    public class AssignmentsController : Controller
    {
        // GET: Assignments
        public ActionResult Index()
        {
            AssignmentsIndex data = new AssignmentsIndex();

            return View(data);
        }
    }
}