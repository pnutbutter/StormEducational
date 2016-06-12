using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DataAccess
{
    [Table("TeacherStudentView")]
    public partial class TeacherStudentView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeacherUserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string TeacherFirstName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string TeacherLastName { get; set; }

        [Column(Order = 3)]
        public string TeacherAspNetUserId { get; set; }

        [Column(Order = 4)]
        public string TeacherEmail { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentUserId { get; set; }

        [Key]
        [Column(Order = 6)]
        public string StudentFirstName { get; set; }

        [Key]
        [Column(Order = 7)]
        public string StudentLastName { get; set; }

        [Column(Order = 8)]
        public string StudentAspNetUserId { get; set; }

        [Column(Order = 9)]
        public string StudentEmail { get; set; }
    }
}
