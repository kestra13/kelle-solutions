using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    public class PersonToEntity
    {
        // Primary Key
        [Key]
        [Required]
        public int Code { get; set; }

        [Required]
        public bool Deprecated { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public short Creator { get; set; }

        [Required]
        public int Person { get; set; }

        [Required]
        public int Entity { get; set; }

        [Required]
        public short Relation { get; set; }

        [MaxLength(100)]
        public string Comments { get; set; } = null!;

        // Foreign Keys
        public virtual Person PersonNavigation { get; set; } = null!;
        public virtual Entity EntityNavigation { get; set; } = null!;
    }
}