namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAssignmentView")]
    public partial class UserAssignmentView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserAssignmentId { get; set; }

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
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssignmentId { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssignmentTypeId { get; set; }

        public int? AssignmentParentId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(250)]
        public string AssignmentTitle { get; set; }

        [Key]
        [Column(Order = 9)]
        public string AssignmentDescription { get; set; }

        [StringLength(250)]
        public string AssignmentSpanishTitle { get; set; }

        public string AssignmentSpanishDescription { get; set; }

        public int? VocabularyId { get; set; }

        public string AssignmentTypeTitle { get; set; }

        public bool IsSubmitted { get; set; }

        public DateTime? SubmittedDate { get; set; }

        public int Grade { get; set; }

        public string GradeDescription { get; set; }
    }
}
