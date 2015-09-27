using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.GroupData
{
    public class GroupConfirmDelete
    {
        [Required]
        public int GroupId { get; set; }

        [Display(Name = "Group Type")]
        public int GroupTypeId { get; set; }

        [Display(Name = "Name")]
        public string GroupName { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}