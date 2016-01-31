using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.Teacher.Models.TeacherAssignmentsData;
using Website.Controllers;

namespace Website.Areas.Teacher.Controllers
{
    public class AssignmentsController : BaseController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Teacher/Assignments
        public ActionResult Index()
        {
            TeacherAssignmentsIndex data = new TeacherAssignmentsIndex();

            //TODO: filter down to ones only assigned by current teacher
            data.ItemList = db.Assignments.ToList();

            return View(data);
        }
    }
}