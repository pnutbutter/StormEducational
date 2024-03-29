﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.Teacher.Models.ClassroomData
{
    public class ClassroomAssign
    {
        public string Message { get; set; }

        public string Search { get; set; }

        public List<TeacherStudentView> ItemList { get; set; }

        public List<UserView> SearchList { get; set; }

        public List<UserView> AssignedList { get; set; }

        public int Id { get; set; }

        public int SchoolId { get; set; }

        public int[] Included { get; set; }

        public int[] Excluded { get; set; }
    }
}