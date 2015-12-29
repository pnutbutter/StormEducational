using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.UserRoleData
{
    public class UserRoleCreate
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Role Type")]
        public int RoleId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}