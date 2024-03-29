﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.Administration.Models.UserData;

namespace Website.Areas.Administration.Controllers
{
    public class UserController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Search(UserSearch data)
        {
            //UserSearch data = new UserSearch();


            return View(data);
        }
        
        // GET: Administration/User
        public ActionResult Index(string Message, string LastName)
        {
            UserIndex data = new UserIndex();

            if (LastName == null)
                data.ItemList = db.Users.ToList();
            else 
                data.ItemList = db.Users.Where(u => u.LastName.ToLower().Contains(LastName.ToLower())).ToList();

            data.Message = Message;

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            UserCreate data = new UserCreate();

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreate data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                User item = new User();
                item.FirstName = data.FirstName;
                item.LastName = data.LastName;
                item.IsActive = data.IsActive;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;
                item.CreateBy = this.User.Identity.Name;
                item.CreateDate = DateTime.Now;

                db.Users.Add(item);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.FirstName + " " + data.LastName + " Saved" });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserEdit data = new UserEdit();

            User item = db.Users.Find(id);
            data.FirstName = item.FirstName;
            data.LastName = item.LastName;
            data.IsActive = item.IsActive;
            data.UserId = item.UserId;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEdit data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                User item = db.Users.Find(data.UserId);
                item.FirstName = data.FirstName;
                item.LastName = data.LastName;
                item.IsActive = data.IsActive;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<User>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.FirstName + " " + data.LastName + " Edits Saved" });
        }

        [HttpGet]
        public ActionResult ConfirmDelete(int id)
        {
            UserConfirmDelete data = new UserConfirmDelete();
            User item = db.Users.Find(id);
            data.FirstName = item.FirstName;
            data.LastName = item.LastName;
            data.IsActive = item.IsActive;
            data.UserId = item.UserId;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(UserConfirmDelete data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                User item = db.Users.Find(data.UserId);
                item.IsActive = false;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<User>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = data.FirstName + " " + data.LastName + " Inactivated" });
        }
    }
}