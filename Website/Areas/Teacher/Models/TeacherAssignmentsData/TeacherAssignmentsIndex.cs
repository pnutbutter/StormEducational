using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.Teacher.Models.TeacherAssignmentsData
{
    public class TeacherAssignmentsIndex
    {
        public string Message { get; set; }

        public List<Assignment> ItemList { get; set; }
    }
}