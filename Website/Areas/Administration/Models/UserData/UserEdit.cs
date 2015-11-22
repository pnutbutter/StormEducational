using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.UserData
{
    public class UserEdit : UserCreate
    {
        [Required]
        public int UserId { get; set; }
    }
}