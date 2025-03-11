// Date: 02/26/2025
// Merging Incoming and Current Listings entity definitions for consistency.
// Adding comments to better explain documentation.

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // connects to existing database relationships

namespace KelleSolutions.Models {
    // Defines the Listing entity and its properties (ex: "ListingID", "Price", etc.)
    public class Listing {
        // Unique ID for each listing (Primary Key)
        [Key]
        public int ListingID { get; set; }

        // Foreign key reference to Property.cs
        [ForeignKey("PropertyID")]
        [Required]
        public int PropertyID { get; set; }

        // Foreign key reference to User.cs (Agent managing the listing)
        [ForeignKey("AgentID")]
        [Required]
        public required string AgentID { get; set; }

        // Defines the listing type (e.g., Sale, Rent)
        [Required]
        [StringLength(50)]
        public required string ListingType { get; set; }

        // Defines the listing price
        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(18,2)")]
        public required decimal Price { get; set; }

        // Defines the listing status
        [Required(ErrorMessage = "Status is required")]
        [Column(TypeName = "nvarchar(50)")]
        public required StatusTypes Status { get; set; }

        // List of pre-defined status types
        public enum StatusTypes {
            [Display(Name = "On Hold")]
            OnHold,
            [Display(Name = "Open House")]
            OpenHouse,
            Active,
            Pending,
            Closed,
            Expired,
            Withdrawn,
            Canceled
        }

        // Defines the listing affiliation type (e.g., Internal, External)
        [Required(ErrorMessage = "Affiliation type is required")]
        [Column(TypeName = "nvarchar(50)")]
        public required AffiliationTypes Affiliation { get; set; }

        // Pre-defined affiliation types
        public enum AffiliationTypes {
            Internal,
            External
        }

        // Defines the date when the listing starts
        [Required]
        public DateTime StartDate { get; set; }

        // Nullable end date if expiration isn't set immediately
        public DateTime? EndDate { get; set; }

        // Timestamp when the listing was created
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Optional description about the listing
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string? Description { get; set; }

        // Navigation properties
        public virtual required Property Property { get; set; }
        public virtual required User Agent { get; set; }
    }
}
