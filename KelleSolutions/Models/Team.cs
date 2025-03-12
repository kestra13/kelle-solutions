using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models {
    public class Team {
        // Primary Key - Short ID for indexing
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short TeamId { get; set; }

        // Unique Affiliation Name (matches AspNetUsers.Affiliation)
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Affiliation { get; set; } = string.Empty;
    }
}
