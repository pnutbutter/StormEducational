using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.DistrictAdmin.Models.SchoolData
{
    public class SchoolIndex
    {
        public string Message { get; set; }

        public List<GroupView> ItemList { get; set; }

        public int DistrictId { get; set; }
    }
}