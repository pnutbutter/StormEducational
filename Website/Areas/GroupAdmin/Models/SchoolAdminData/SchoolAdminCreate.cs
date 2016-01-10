using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.GroupAdmin.Models.SchoolAdminData
{
    public class SchoolAdminCreate
    {
        public int GroupId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}