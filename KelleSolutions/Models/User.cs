// Date: 02/11/2025
// Updating User.cs to reflect User Entity in ERD.
// Adding comments to better explain documentation.

// ASP.NET has built-in login and user management that can be referenced using this line.
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models {
    // User inherits everything from IdentityUser but gets to add extra details, as seen below!
    public class User : IdentityUser
    {
        // User does not need to redefine properties from IdentityUser (ex: "Email", "PhoneNumber", "PasswordHash", etc.)
        // Properties that were not defined in IdentityUser but are still needed have been described here.
        // In terminal, use command "dotnet ef dbcontext script" to view the table "AspNetUsers", which defines
        // all default properties provided by Microsoft.AspNetCore.Identity

        // Required Personal files
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Affiliation { get; set; }
        public required string LicenseNumber { get; set; }

        // Additional properties from ERD that do exist in IdentityUser superclass:
        public bool IsTenant { get; set; }

        // Tenant relationship
        public int? TenantID { get; set; }  // Nullable, because a user may initially not belong to any tenant

        [ForeignKey("TenantID")]
        public virtual Tenant? Tenant { get; set; }
<<<<<<< HEAD
=======

        // Timestamps
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        public virtual Dashboard Dashboard { get; set; } // One-to-One relationship
>>>>>>> ac7a374014d444c8b4faf860756d2f65e15f04fa
    }
}
