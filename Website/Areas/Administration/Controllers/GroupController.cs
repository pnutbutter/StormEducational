using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.Administration.Models.GroupData;

namespace Website.Areas.Administration.Controllers
{
    public class GroupController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        
        // GET: Administration/Group
        public ActionResult Index(string Message)
        {
            GroupIndex data = new GroupIndex();

            data.ItemList = db.Groups.ToList();
            data.Message = Message;
       
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            GroupCreate data = new GroupCreate();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroupCreate data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                Group item = new Group();
                item.GroupName = data.GroupName;
                item.IsActive = data.IsActive;
                item.GroupTypeId = data.GroupTypeId;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;
                item.CreateBy = this.User.Identity.Name;
                item.CreateDate = DateTime.Now;

                db.Groups.Add(item);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.GroupName + " Saved" });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GroupEdit data = new GroupEdit();
            Group item = db.Groups.Find(id);
            data.GroupName = item.GroupName;
            data.IsActive = item.IsActive;
            data.GroupTypeId = item.GroupTypeId;
            data.GroupId = item.GroupId;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GroupEdit data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                Group item = db.Groups.Find(data.GroupId);
                item.GroupName = data.GroupName;
                item.IsActive = data.IsActive;
                item.GroupTypeId = data.GroupTypeId;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<Group>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.GroupName + " Edits Saved" });
        }

        [HttpGet]
        public ActionResult ConfirmDelete(int id)
        {
            GroupConfirmDelete data = new GroupConfirmDelete();
            Group item = db.Groups.Find(id);
            data.GroupName = item.GroupName;
            data.IsActive = item.IsActive;
            data.GroupTypeId = item.GroupTypeId;
            data.GroupId = item.GroupId;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(GroupConfirmDelete data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                Group item = db.Groups.Find(data.GroupId);
                item.IsActive = false;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<Group>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.GroupName + " Inactivated" });
        }
    }
}