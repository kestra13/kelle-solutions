using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    public class TenantToPerson
    {
        [Key]
        public int TenantToPersonID { get; set; }

        [Required]
        public int TenantID { get; set; }

        [Key]
        [MaxLength(450)]
        public required string PersonID { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Role { get; set; }

        // Navigation Properties
        public Tenant Tenant { get; set; } = null!;
        public User Person { get; set; } = null!;
    }
}
