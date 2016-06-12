using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Areas.Project.Models.VocabularyData
{
    public class Word
    {
        public int VocabularyId { get; set; }

        public int UserAssignmentId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Word")]
        public string VocabWord { get; set; }

        [StringLength(250)]
        [Display(Name="Part of Speech")]
        public string PartOfSpeech { get; set; }

        [StringLength(250)]
        public string Etymology { get; set; }

        [StringLength(250)]
        public string Connotation { get; set; }

        [Display(Name = "Friendly Definition")]
        public string FriendlyDefinition { get; set; }

        [AllowHtml]
        public string Sketch { get; set; }

        [Display(Name="Sketch Name")]
        public string SketchName { get; set; }

        [StringLength(250)]
        public string Adjective { get; set; }

        [StringLength(250)]
        [Display(Name = "Singular")]
        public string NounSingular { get; set; }

        [StringLength(250)]
        [Display(Name = "Plural")]
        public string NounPlural { get; set; }

        [Display(Name = "Verb Tense")]
        public int? VerbTenseTypeId { get; set; }

        [StringLength(250)]
        [Display(Name = "I")]
        public string VerbTenseI { get; set; }

        [StringLength(250)]
        [Display(Name = "We")]
        public string VerbTenseWe { get; set; }

        [StringLength(250)]
        [Display(Name = "You")]
        public string VerbTenseYou { get; set; }

        [StringLength(250)]
        [Display(Name = "You")]
        public string VerbTenseYou2 { get; set; }

        [StringLength(250)]
        [Display(Name = "He,She,It")]
        public string VerbTenseHeSheIt { get; set; }

        [StringLength(250)]
        [Display(Name = "They")]
        public string VerbTenseThey { get; set; }

        [StringLength(250)]
        public string Synonym { get; set; }

        [StringLength(250)]
        public string Antonym { get; set; }

        public string Sentence { get; set; }

        public string Analogy { get; set; }

        [Display(Name = "Word Array")]
        public string[] WordArray { get; set; }

        public int[] WordArrayIds { get; set; }
    }
}