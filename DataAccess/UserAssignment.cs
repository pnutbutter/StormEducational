namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAssignment")]
    public partial class UserAssignment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAssignment()
        {
            VocabularyAssignments = new HashSet<VocabularyAssignment>();
        }
        public int UserAssignmentId { get; set; }

        public int AssignmentId { get; set; }

        public int AssignedUserId { get; set; }

        public int AssigningUserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        public int Grade { get; set; }

        [Required]
        public string GradeDescription { get; set; }

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

        public virtual Assignment Assignment { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VocabularyAssignment> VocabularyAssignments { get; set; }
    }
}
