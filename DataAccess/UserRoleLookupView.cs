namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRoleLookupView")]
    public partial class UserRoleLookupView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }
 
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(128)]
        public string AspNetUserId { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserRoleId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }
    }
}

