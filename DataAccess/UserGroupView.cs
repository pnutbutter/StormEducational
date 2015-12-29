namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserGroupView")]
    public partial class UserGroupView
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string ScreenName { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserGroupId { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupId { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupTypeId { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string GroupName { get; set; }
    }
}
