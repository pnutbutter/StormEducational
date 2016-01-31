using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website.Areas.GroupAdmin.Models.SchoolAdminData
{
    public class SchoolAdminEmail
    {
        public int GroupId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }
        
        public string Message { get; set; }

        [Display(Name = "Recipient Email Address(s) (Seperate Multiple Emails by Commas")]
        public string EmailList { get; set; }
    }
}