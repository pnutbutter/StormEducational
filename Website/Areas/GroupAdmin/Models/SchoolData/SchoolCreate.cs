using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.GroupAdmin.Models.SchoolData
{
    public class SchoolCreate
    {
        [Required]
        [Display(Name = "Name")]
        public string GroupName { get; set; }


        [Display(Name = "School Admin Email")]
        public string SchoolAdminEmail { get; set; }
    }
}