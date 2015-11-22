using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.UserData
{
    public class UserConfirmDelete
    {
        [Required]
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Screen Name")]
        public string ScreenName { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}