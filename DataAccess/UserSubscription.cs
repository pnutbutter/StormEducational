namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserSubscription")]
    public partial class UserSubscription
    {
        public int UserSubscriptionId { get; set; }

        public int SubscriptionId { get; set; }

        public int UserId { get; set; }

        public decimal? LastPayment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastPaymentDate { get; set; }

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

        public virtual Subscription Subscription { get; set; }

        public virtual User User { get; set; }
    }
}
