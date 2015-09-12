namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssignmentType")]
    public partial class AssignmentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssignmentType()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int AssignmentTypeId { get; set; }

        [Required]
        [StringLength(250)]
        public string AssignmentTypeTitle { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
