using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Common;

namespace KelleSolutions.Models
{
    public class PersonToPerson
    {
        //primary key
        [Key]
        [Required]
        public required int Code {get;set;}

        [Required]
        public required bool Deprecated {get;set;}

        [Required]
        [Column("DateTime2")]
        public required DateTime Created {get;set;}

        public required short Creator {get;set;}

        public int PersonId {get;set;}

        public int Person2Id{get;set;}

        [Required]
        public required short Relation{get;set;}

        [Required]
        [MaxLength(100)]
        public required string Comments {get;set;}

        //Navigation to Foreign Keys
        public Person ? Person {get;set;}

        public Person ? Person2 {get; set;}

        
    }
}