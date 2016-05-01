using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.Teacher.Models.ClassroomData
{
    public class ClassroomIndex
    {
        public string Message { get; set; }

        public List<GroupView> ItemList { get; set; }
    }
}