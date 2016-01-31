using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class BaseController : Controller
    {
        protected DatabaseContext db = new DatabaseContext();

        private UserView CurrentUser = null;

        public UserView GetCurrentUser()
        {
            if(CurrentUser==null)
                CurrentUser = db.UserViews.Where(uv => uv.Email.Trim() == this.HttpContext.User.Identity.Name.Trim()).FirstOrDefault();
            return CurrentUser;
            
        }
    }
}