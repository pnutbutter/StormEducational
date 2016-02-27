namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VocabularyWordArray")]
    public partial class VocabularyWordArray
    {
        public int VocabularyWordArrayId { get; set; }

        public int WordArrayId { get; set; }

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

        public virtual WordArray WordArray { get; set; }

        public virtual Vocabulary Vocabulary { get; set; }
    }
}
