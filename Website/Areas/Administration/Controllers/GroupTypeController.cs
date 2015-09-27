using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.Administration.Models.GroupTypeData;

namespace Website.Areas.Administration.Controllers
{
    public class GroupTypeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Administration/GroupType
        public ActionResult Index(string Message)
        {
            GroupTypeIndex data = new GroupTypeIndex();

            data.ItemList = db.GroupTypes.ToList();
            data.Message = Message;

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            GroupTypeCreate data = new GroupTypeCreate();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroupTypeCreate data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                GroupType item = new GroupType();
                item.GroupName = data.GroupTypeName;
                item.IsActive = data.IsActive;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;
                item.CreateBy = this.User.Identity.Name;
                item.CreateDate = DateTime.Now;

                db.GroupTypes.Add(item);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.GroupTypeName + " Saved" });
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            GroupTypeEdit data = new GroupTypeEdit();
            GroupType item = db.GroupTypes.Find(id);
            data.GroupTypeName = item.GroupName;
            data.IsActive = item.IsActive;
            data.GroupTypeId = item.GroupTypeId;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GroupTypeEdit data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                GroupType item = db.GroupTypes.Find(data.GroupTypeId);
                item.GroupName = data.GroupTypeName;
                item.IsActive = data.IsActive;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<GroupType>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.GroupTypeName + " Edits Saved" });
        }

        [HttpGet]
        public ActionResult ConfirmDelete(int id)
        {
            GroupTypeConfirmDelete data = new GroupTypeConfirmDelete();
            GroupType item = db.GroupTypes.Find(id);
            data.GroupTypeName = item.GroupName;
            data.IsActive = item.IsActive;
            data.GroupTypeId = item.GroupTypeId;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(GroupTypeConfirmDelete data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                GroupType item = db.GroupTypes.Find(data.GroupTypeId);
                item.IsActive = false;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<GroupType>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.GroupTypeName + " Inactivated" });
        }


    }
}