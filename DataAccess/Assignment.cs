namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Assignment")]
    public partial class Assignment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignment()
        {
            Assignment1 = new HashSet<Assignment>();
            UserAssignments = new HashSet<UserAssignment>();
        }

        public int AssignmentId { get; set; }

        public int AssignmentTypeId { get; set; }

        public int? AssignmentParentId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        [Required]
        [StringLength(250)]
        public string AssignmentTitle { get; set; }

        [Required]
        public string AssignmentDescription { get; set; }

        [StringLength(250)]
        public string AssignmentSpanishTitle { get; set; }

        public string AssignmentSpanishDescription { get; set; }

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
        public virtual ICollection<Assignment> Assignment1 { get; set; }

        public virtual Assignment Assignment2 { get; set; }

        public virtual AssignmentType AssignmentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAssignment> UserAssignments { get; set; }

        public int UserId { get; set; }

        
    }
}
