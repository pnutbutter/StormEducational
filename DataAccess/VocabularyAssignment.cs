namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VocabularyAssignment")]
    public partial class VocabularyAssignment
    {
        public int VocabularyAssignmentId { get; set; }

        public int AssignmentId { get; set; }

        public int VocabularyId { get; set; }

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

        public virtual Vocabulary Vocabulary { get; set; }
    }
}
