using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.GroupTypeData
{
    public class GroupTypeConfirmDelete
    {
        [Required]
        public int GroupTypeId { get; set; }

        [Display(Name = "Name")]
        public string GroupTypeName { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}