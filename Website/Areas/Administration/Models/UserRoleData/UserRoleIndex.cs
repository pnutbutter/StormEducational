using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.UserRoleData
{   
    public class UserRoleIndex
    {
        public string Message { get; set; }

        public List<UserRoleView> ItemList { get; set; }

        public decimal UserId { get; set; }
    }
}