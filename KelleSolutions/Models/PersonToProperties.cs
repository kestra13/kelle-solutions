using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KelleSolutions.Controllers;

namespace KelleSolutions.Models
{
    public class PersonToProperties
    {
        //primary key
        [Key]
        [Required]
        public required int Code {get;set;}

        [Required]
        public required bool Deprecated {get;set;}

        [Required]
        [Column(TypeName ="DateTime2")]
        public required DateTime Created {get;set;}

        [Required]
        public required short Creator {get;set;}
        public required int Person {get;set;}

        public required int Properties {get;set;}

        [Required]
        public required short Relation{get;set;}

        [Required]
        [MaxLength(100)]
        public required string Comments {get;set;}

        //navigation property for foreign keys
        public Person ? People {get;set;}

        public Property ? Property {get;set;}

    }
}
