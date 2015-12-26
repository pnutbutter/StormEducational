using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.GroupAdmin.Models.SchoolData
{
    public class SchoolIndex
    {
        public string Message { get; set; }

        public List<GroupView> ItemList { get; set; }
    }
}