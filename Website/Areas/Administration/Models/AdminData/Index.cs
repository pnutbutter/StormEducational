using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.AdminData
{
    public class Index
    {
        public decimal GroupId { get; set; }

        public decimal GroupTypeId { get; set; }

        [StringLength(50)]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }

        [Display(Name = "Is Group Active?")]
        public bool IsActive { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime ChangeDate { get; set; }

        public string ChangeBy { get; set; } 
    }
}