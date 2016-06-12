using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.DistrictAdmin.Models.SchoolData
{
    public class SchoolEdit : SchoolCreate
    {
        [Required]
        public int GroupId { get; set; }
    }
}