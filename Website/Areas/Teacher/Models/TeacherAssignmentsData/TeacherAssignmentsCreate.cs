using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Teacher.Models.TeacherAssignmentsData
{
    public class TeacherAssignmentsCreate
    {
        [Required]
        [Display(Name="Assignment Type")]
        public int AssignmentTypeId { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Title")]
        public string AssignmentTitle { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string AssignmentDescription { get; set; }

        [StringLength(250)]
        [Display(Name = "Spanish Title")]
        public string AssignmentSpanishTitle { get; set; }

        [Display(Name = "Spanish Description")]
        public string AssignmentSpanishDescription { get; set; }
    }
}