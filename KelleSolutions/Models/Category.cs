using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models {
    // Maps to the "Categories" table in the database
    [Table("Categories")]
    public class Category {
        // Stores category ID (1, 2, 3)
        [Key]
        public short CategoryId { get; set; }

        // Stores category name (Admin, Broker, Agent)
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;
    }
}
