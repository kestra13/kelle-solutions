using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    public class User : IdentityUser
    {
        // Personal details
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        [MaxLength(255)]
        public string Affiliation { get; set; } = null!;

        [MaxLength(50)]
        public string LicenseNumber { get; set; } = string.Empty;

        public bool IsTenant { get; set; }

        // Foreign Key to Role Table
        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; } = null!;

        // Foreign Key to Tenant Table (Restored from previous model)
        public int? TenantID { get; set; }  // Nullable in case a user is not assigned a tenant

        [ForeignKey("TenantID")]
        public virtual Tenant? Tenant { get; set; }

        // Timestamps
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
    }
}
