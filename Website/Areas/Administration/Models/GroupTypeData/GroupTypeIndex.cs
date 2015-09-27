using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.GroupTypeData
{
    public class GroupTypeIndex
    {
        public string Message { get; set; }
        public List<GroupType> ItemList { get; set; }
    }
}