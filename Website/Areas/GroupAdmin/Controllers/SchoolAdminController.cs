using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.GroupAdmin.Models.SchoolAdminData;

using System.Net.Http;
using System.Net.Mail;
using SendGrid;
using System.Net;
using System.Configuration;


using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Website.Models;
using System.Diagnostics;


namespace Website.Areas.GroupAdmin.Controllers
{
    public class SchoolAdminController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Administration/Group
        [Authorize]
        public ActionResult Index(string Message, int id)
        {
            SchoolAdminIndex data = new SchoolAdminIndex();

            // Role Id for School Admin is 2
            data.ItemList = db.UserRoleGroupViews.Where(u => u.RoleId == 2 && u.GroupId == id).ToList();

            data.Message = Message;
            data.GroupId = id;

            return View(data);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create(int GroupId)
        {
            SchoolAdminCreate data = new SchoolAdminCreate();
            ViewBag.UserId = new SelectList(db.Users, "UserId", "NameFull");
            data.GroupId = GroupId;
            return View(data);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolAdminCreate data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                //Relate user to group via UserGroup Table
                UserGroup userGroupItem = new UserGroup();
                userGroupItem.UserId = data.UserId;
                userGroupItem.GroupId = data.GroupId;
                userGroupItem.IsActive = true;
                userGroupItem.ChangeBy = this.User.Identity.Name;
                userGroupItem.ChangeDate = DateTime.Now;
                userGroupItem.CreateBy = this.User.Identity.Name;
                userGroupItem.CreateDate = DateTime.Now;

                db.UserGroups.Add(userGroupItem);
                db.SaveChanges();

                //Relate User to role via UserRole table
                UserRole userRoleItem = new UserRole();
                userRoleItem.UserId = data.UserId;
                userRoleItem.RoleId = 2;
                userRoleItem.IsActive = true;
                userRoleItem.ChangeBy = this.User.Identity.Name;
                userRoleItem.ChangeDate = DateTime.Now;
                userRoleItem.CreateBy = this.User.Identity.Name;
                userRoleItem.CreateDate = DateTime.Now;

                db.UserRoles.Add(userRoleItem);
                db.SaveChanges();

            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = "Saved User as School Administrator", id = data.GroupId });
        }

        [HttpGet]
        [Authorize]
        public ActionResult Email(int GroupId)
        {
            SchoolAdminEmail data = new SchoolAdminEmail();
            data.GroupId = GroupId;
            return View(data);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Email(SchoolAdminEmail data)
        {
            
            
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }


                //parse email list
                string[] emailArray = data.EmailList.Split(',');

                for (int i = 0; i < emailArray.Length; i++)
                {
                    //Validate email?



                    string Gary = emailArray[i];
                    
                    //Send Email
                    var myMessage = new SendGridMessage();
                    myMessage.AddTo(emailArray[i]);
                    myMessage.From = new System.Net.Mail.MailAddress("Gary03082000@gmail.com", "Gary L.");
                    myMessage.Subject = "New Admin Request";
                    myMessage.Text = "Has requested you as an administrator ...  Please click on the link below to access the application.";
                    myMessage.Html = "www.google.com";

                    var credentials = new NetworkCredential(
                               ConfigurationManager.AppSettings["mailAccount"],
                               ConfigurationManager.AppSettings["mailPassword"]
                               );

                    // Create a Web transport for sending email.
                    var transportWeb = new Web(credentials);

                    // Send the email.
                    if (transportWeb != null)
                    {
                        //await transportWeb.DeliverAsync(myMessage);
                    }
                    else
                    {
                        //Trace.TraceError("Failed to create Web transport.");
                        //await Task.FromResult(0);
                    }
                }


                

                
                //db.SaveChanges();

            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { Message = "Email(s) have been sent.", id = data.GroupId });
        }

        [HttpGet]
        [Authorize]
        public ActionResult ConfirmDelete(int UserRoleId, int GroupId)
        {
            SchoolAdminConfirmDelete data = new SchoolAdminConfirmDelete();

            data.UserRoleId = UserRoleId;
            data.GroupId = GroupId;

            UserRole userRole = db.UserRoles.Find(UserRoleId);
                   
            User item = db.Users.Find(userRole.UserId);
            data.FirstName = item.FirstName;
            data.LastName = item.LastName;

            return View(data);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(SchoolAdminConfirmDelete data)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }

                UserRole item = db.UserRoles.Find(data.UserRoleId);
                item.IsActive = false;
                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                db.Entry<UserRole>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index", new { id = data.GroupId, Message = " School admin role for " + data.FirstName + data.LastName + "  has been inactivated" });
        }
    }
}