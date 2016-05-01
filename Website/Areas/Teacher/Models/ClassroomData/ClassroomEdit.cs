using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Teacher.Models.ClassroomData
{
    public class ClassroomEdit : ClassroomCreate
    {
        [Required]
        public int GroupId { get; set; }
    }
}