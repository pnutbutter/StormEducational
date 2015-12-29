using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.UserRoleData
{
    public class UserRoleEdit : UserRoleCreate
    {
        [Required]
        public int UserRoleId { get; set; }
    }
}