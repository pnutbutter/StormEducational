using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.UserData
{
    public class UserIndex
    {
        public string Message { get; set; }

        public List<User> ItemList { get; set; }
    }
}