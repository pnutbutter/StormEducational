using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Areas.Administration.Models.GroupData
{
    public class GroupEdit : GroupCreate
    {
        [Required]
        public int GroupId { get; set; }
    }
}