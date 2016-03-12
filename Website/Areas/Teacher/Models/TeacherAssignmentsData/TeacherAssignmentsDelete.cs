using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Teacher.Models.TeacherAssignmentsData
{
    public class TeacherAssignmentsDelete
    {
        public int AssignmentId { get; set; }

        [Display(Name = "Title")]
        public string AssignmentTitle { get; set; }

        [Display(Name = "Description")]
        public string AssignmentDescription { get; set; }
    }
}