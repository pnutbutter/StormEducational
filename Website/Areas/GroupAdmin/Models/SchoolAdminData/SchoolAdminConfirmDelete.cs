using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.GroupAdmin.Models.SchoolAdminData
{
    public class SchoolAdminConfirmDelete
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public decimal UserRoleId { get; set; }

        public decimal GroupId { get; set; }
    }
}