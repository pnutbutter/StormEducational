using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.UserGroupData
{
    public class UserGroupIndex
    {
        public string Message { get; set; }

        public List<UserGroupView> ItemList { get; set; }

        public decimal UserId { get; set; }
    }
}