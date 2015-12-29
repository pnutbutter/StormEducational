using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.UserGroupData
{
    public class UserGroupEdit : UserGroupCreate
    {
        [Required]
        public int UserGroupId { get; set; }
    }
}