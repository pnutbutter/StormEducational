using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.GroupData
{
    public class GroupIndex
    {
        public string Message { get; set; }

        public List<GroupView> ItemList { get; set; }
    }
}