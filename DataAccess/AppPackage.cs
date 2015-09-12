namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AppPackage")]
    public partial class AppPackage
    {
        public int AppPackageId { get; set; }

        public int AppId { get; set; }

        public int SubscriptionId { get; set; }

        [Required]
        [StringLength(50)]
        public string PackageName { get; set; }

        [Required]
        public string PackageDescription { get; set; }

        public decimal PackagePrice { get; set; }

        public int PackageTypeId { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreateBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime ChangeDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ChangeBy { get; set; }

        public virtual App App { get; set; }

        public virtual Subscription Subscription { get; set; }
    }
}
