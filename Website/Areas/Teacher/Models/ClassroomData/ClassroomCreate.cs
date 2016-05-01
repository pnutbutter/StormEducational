using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Teacher.Models.ClassroomData
{
    public class ClassroomCreate
    {
        [Required]
        [Display(Name = "Name")]
        public string GroupName { get; set; }
    }
}