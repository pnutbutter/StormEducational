using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Website.Areas.Administration.Models.UserData
{
    public class UserSearch
    {
        public bool HasSearched { get; set; }

        [Display(Name  = "Last Name:")]
        public string LastName { get; set; }

        public string Message { get; set; }
    }
}