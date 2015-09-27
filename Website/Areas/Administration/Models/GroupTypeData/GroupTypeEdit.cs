using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.GroupTypeData
{
    public class GroupTypeEdit : GroupTypeCreate
    {
        [Required]
        public int GroupTypeId { get; set; }
    }
}