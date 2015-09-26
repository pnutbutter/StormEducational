using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Website.Areas.Administration.Models.GroupData;

namespace Website.Areas.Administration.Controllers
{
    public class GroupController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        
        // GET: Administration/Group
        public ActionResult Index(int? GroupId)
        {
            GroupIndex data = new GroupIndex();

            //var groups = db.Groups.Include(v => v.)
            data.GroupList = db.Groups.ToList();
            
            return View(data);
        }
    }
}