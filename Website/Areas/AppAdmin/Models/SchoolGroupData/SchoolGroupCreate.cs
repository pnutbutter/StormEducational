using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.AppAdmin.Models.SchoolGroupData
{
    public class SchoolGroupCreate
    {
        [Required]
        [Display(Name = "Name")]
        public string GroupName { get; set; }

        [Required]
        [Display(Name="Type")]
        public int GroupTypeId { get; set; }

    }
}