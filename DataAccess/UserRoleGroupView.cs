﻿namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRoleGroupView")]
    public partial class UserRoleGroupView
    {
        //TODO: Gary - Including the primary key in the view throws the error below.
        // " The specified cast from a materialized 'System.Int64' type to the 'System.Int32' type is not valid:"

        //[Key]
        //[Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int UserRoleGroupViewId { get; set; }

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
        public int RoleId { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string RoleName { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupId { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupTypeId { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string GroupName { get; set; }
    }
}
