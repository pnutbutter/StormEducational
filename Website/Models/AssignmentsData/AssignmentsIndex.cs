using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models.AssignmentsData
{
    public class AssignmentsIndex
    {
        public List<UserAssignmentView> ItemList { get; set; }

        public List<UserAssignmentView> SubmittedItemList { get; set; }
    }
}