using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.DistrictAdmin.Models.SchoolData
{
    public class SchoolDelete
    {
        public int GroupId { get; set; }

        [Display(Name = "Name")]
        public string GroupName { get; set; }
    }
}