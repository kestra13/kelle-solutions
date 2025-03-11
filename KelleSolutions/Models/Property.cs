// Date: 02/11/2025
// Updating Property.cs to reflect Properties Entity in ERD.
// Formerly titled "RealEstateProperty.cs".
// Adding comments to better explain documentation.

// "[Required]" field needed in form and database validations
// "required" keyword complies to C#'s object creation

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; // defines database relationships

namespace KelleSolutions.Models {
    // Defines the Property entity and its properties (ex: "PropertyId", "PropertyName", etc.)
    public class Property {
        
        // Unique ID (or APN) for each property (PK), APN will be considered later
        public int PropertyID { get; set; }

        public string? OwnerID { get; set; }

    //  [ForeignKey("OwnerID")]
    //  public required User Owner { get; set; }

        // Track whether the property is archived or not, default false
        public Boolean IsArchived { get; set; } = false;

        // The full address of the property (ex: "6000 J St"), required field
        [Required(ErrorMessage = "Address is required")]
        public required string Address { get; set; }

        // City where the property is located (ex: "Sacramento", "Modesto", etc.), required field
        [Required(ErrorMessage = "City is required")]
        public required string City { get; set; }

        // Stae where the property is located (ex: "California", "Nevada", "Oregon", etc.), required field
        [Required(ErrorMessage = "State is required")]
        public required string State { get; set; }

        // Postal code (ex: "12345", "67890", etc.), required field
        [Required(ErrorMessage = "Zip Code is required")]
        public required string ZipCode { get; set; }

        // Property size in square feet (if applicable)
        public int? Size { get; set; }

        // Land size in square feet (if applicable)
        public int? LandSize { get; set; }

        // Number of bedrooms on the property, required field
        [Required(ErrorMessage = "Number of bedrooms is required")]
        public required int BedCount {get; set; }

        // Number of bathrooms on the property, required field
        [Required(ErrorMessage = "Number of bathrooms is required")]
        public required int BathCount {get; set; }

        // Number of garages on the property, required field
        [Required(ErrorMessage = "Number of garages is required")]
        public required int GarageCount {get; set; }

        // Track whether property is complex or not, default false
        public Boolean IsComplex { get; set; } = false;

        // Number of partials (ex: selling or leasing one room) (if applicable), default 0
        public int PartialCount { get; set; } = 0;

        // Year when the property was constructed, required field
        [Required(ErrorMessage = "Year of construction is required")]
        public required int YearConstructed { get; set; }

        // Track whether property is remodeled or not, default false
        public Boolean IsRemodeled { get; set; } = false;

        // Additional notes made on property (if applicable)
        [StringLength(255, ErrorMessage = "Note cannot exceed 255 characters.")]
        public string? Notes {get; set; } = string.Empty;

        // Defines the property by assigned case (SQL query shown below).
        [Column(TypeName = "nvarchar(50)")]
        public required string PropertyType { get; set; }

        /*
        CASE 
        WHEN PropertyType = 'SingleFamilyHome' THEN 0
        WHEN PropertyType = 'MultiFamilyHome' THEN 1
        WHEN PropertyType = 'Condominium' THEN 2
        WHEN PropertyType = 'Townhouse' THEN 3
        WHEN PropertyType = 'Apartment' THEN 4
        WHEN PropertyType = 'OfficeBuilding' THEN 5
        WHEN PropertyType = 'RetailStore' THEN 6
        WHEN PropertyType = 'Warehouse' THEN 7
        WHEN PropertyType = 'VacantLand' THEN 8
        ELSE 9 -- "Other"
        */
        
        // List of pre-defined property types
        public enum PropertyTypes {
            [Display(Name = "Single Family Home")]
            SingleFamilyHome,

            [Display(Name = "Multi Family Home")]
            MultiFamilyHome,

            [Display(Name = "Condominium")]
            Condominium,

            [Display(Name = "Townhouse")]
            Townhouse,

            [Display(Name = "Apartment")]
            Apartment,

            [Display(Name = "Office Building")]
            OfficeBuilding,

            [Display(Name = "Retail Store")]
            RetailStore,

            [Display(Name = "Warehouse")]
            Warehouse,

            [Display(Name = "Vacant Land")]
            VacantLand,

            [Display(Name = "Other")]
            Other
        }

        // Date the property was added to the system
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? TenantID { get; set; }

        [ForeignKey("TenantID")]
        public virtual Tenant? Tenant { get; set; }

        // The UserID to track which user created this property
        [Required]
        public required string UserID { get; set; }

        // Foreign key reference to User.cs
        [ForeignKey("UserID")]
        public virtual User? User { get; set; }

        // Navigation property, Property can have multiple listings in its lifetime
        public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();

    }
}
