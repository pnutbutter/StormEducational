using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Teacher.Models.ClassroomData
{
    public class ClassroomDelete
    {
        public int GroupId { get; set; }

        [Display(Name = "Name")]
        public string GroupName { get; set; }

    }
}