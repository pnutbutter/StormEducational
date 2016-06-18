namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupView")]
    public partial class GroupView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupTypeId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? ParentGroupId { get; set; }

        [StringLength(50)]
        public string GroupName { get; set; }

        public bool IsActive { get; set; }

        public int? OwnerUserId { get; set; }

        [StringLength(50)]
        public string GroupTypeName { get; set; }


    }
}
