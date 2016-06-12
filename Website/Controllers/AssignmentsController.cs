using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models.AssignmentsData;

namespace Website.Controllers
{
    public class AssignmentsController : BaseController
    {
        // GET: Assignments
        public ActionResult Index()
        {
            AssignmentsIndex data = new AssignmentsIndex();
            int userid = GetCurrentUser().UserId;
            data.ItemList = db.UserAssignmentViews.Where(v => v.UserId == userid).ToList();

            return View(data);
        }
    }
}