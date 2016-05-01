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

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupTypeId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string GroupName { get; set; }

        [Column(Order = 3)]
        public bool IsActive { get; set; }

        [Column(Order = 4)]
        public int? OwnerUserId { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string GroupTypeName { get; set; }


    }
}
