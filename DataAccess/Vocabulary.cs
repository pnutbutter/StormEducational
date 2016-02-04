namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vocabulary")]
    public partial class Vocabulary
    {
        public int VocabularyId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(250)]
        public string Word { get; set; }

        [StringLength(250)]
        public string PartOfSpeech { get; set; }

        [StringLength(250)]
        public string Etymology { get; set; }

        [StringLength(250)]
        public string Connotation { get; set; }

        public string FriendlyDefinition { get; set; }

        [StringLength(250)]
        public string Adjective { get; set; }

        [StringLength(250)]
        public string NounSingular { get; set; }

        [StringLength(250)]
        public string NounPlural { get; set; }

        public int? VerbTenseTypeId { get; set; }

        [StringLength(250)]
        public string VerbTenseI { get; set; }

        [StringLength(250)]
        public string VerbTenseWe { get; set; }

        [StringLength(250)]
        public string VerbTenseYou { get; set; }

        [StringLength(250)]
        public string VerbTenseYou2 { get; set; }

        [StringLength(250)]
        public string VerbTenseHeSheIt { get; set; }

        [StringLength(250)]
        public string VerbTenseThey { get; set; }

        [StringLength(250)]
        public string Synonym { get; set; }

        [StringLength(250)]
        public string Antonym { get; set; }

        public string Sentance { get; set; }

        public string Analogy { get; set; }

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

        public string Sketch { get; set; }

        public virtual User User { get; set; }

        public virtual VerbTenseType VerbTenseType { get; set; }
    }
}
