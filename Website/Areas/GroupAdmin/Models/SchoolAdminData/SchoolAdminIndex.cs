using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.GroupAdmin.Models.SchoolAdminData
{
    public class SchoolAdminIndex
    {
        public string Message { get; set; }

        public List<UserRoleGroupView> ItemList { get; set; }

        public int GroupId { get; set; } 
    }
}