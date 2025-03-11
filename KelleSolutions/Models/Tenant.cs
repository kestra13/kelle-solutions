using System.ComponentModel.DataAnnotations;

namespace KelleSolutions.Models
{
    public class Tenant
    {
        [Key]
        public int TenantID { get; set; }

        [Required]
        [MaxLength(3)]
        public required string TenantCode { get; set; }

        [MaxLength(200)]
        public required string Website { get; set; }

        [MaxLength(20)]
        public required string PhoneNumber { get; set; }

        public int LicenseOperator { get; set; }

        // Navigation Property
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<TenantToPerson> TenantToPeople { get; set; } = new List<TenantToPerson>();
    }
}
