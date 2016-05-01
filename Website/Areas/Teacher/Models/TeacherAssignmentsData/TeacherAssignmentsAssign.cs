using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.Teacher.Models.TeacherAssignmentsData
{
    public class TeacherAssignmentsAssign
    {
        public int AssignmentId { get; set; }

        public List<UserView> Students { get; set; }

        public int[] SelectedStudents { get; set; }

        public DateTime[] DueDates { get; set; }
    }
}