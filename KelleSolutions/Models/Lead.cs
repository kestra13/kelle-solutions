// Date: 02/11/2025
// Updating Lead.cs to reflect Leads Entity in ERD.
// Adding comments to better explain documentation.
//
// "[Required]" field needed in form and database validations
// "required" keyword complies to C#'s object creation

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models {
    public class Lead {
        // Primary key: Code (bigint NOT NULL) -- changed to int bc not compatible to link to person
        [Key]
        public int Code { get; set; }

        // Indicates if the lead is archived (bit NOT NULL)
        [Required]
        public bool Archived { get; set; }

        // Timestamp when the lead was created (datetime2 NOT NULL)
        [Column(TypeName = "datetime2")]
        public DateTime ? Created{ get; set; }

        // Timestamp when the lead was last updated (datetime2 NOT NULL)
        [Column(TypeName = "datetime2")]
        public DateTime ? Updated { get; set; }

        // Operator field (smallint NOT NULL)
        [Required]
        [Column(TypeName = "smallint")]
        public OperatorEnum Operator { get; set; }

        // Originator field (smallint NOT NULL)
        [Required]
        [Column(TypeName = "smallint")]
        public OriginatorEnum Originator { get; set; }

        // Team field (smallint NOT NULL)
        [Required]
        [Column(TypeName = "smallint")]
        public TeamEnum Team { get; set; }

        // Visibility field (tinyint NOT NULL)
        [Required]
        [Column(TypeName = "tinyint")]
        public VisibilityEnum Visibility { get; set; }

        // Campaign identifier (int, optional)
        public int? Campaign { get; set; }

        // Person identifier (int, optional)
        public int? Person { get; set; }

        // Flag indicating if the stage has been worked (bit NOT NULL)
        [Required]
        public bool StageWorked { get; set; }

        // Flag indicating if the lead is marked as temporarily warm (bit NOT NULL)
        [Required]
        public bool TempWarm { get; set; }

        // First name of the lead (varchar(30) NOT NULL)
        [Required(ErrorMessage = "First name is required")]
        [StringLength(30)]
        public required string NameFirst { get; set; }

        // Middle name of the lead (varchar(30) NOT NULL)
        [Required(ErrorMessage = "Middle name is required")]
        [StringLength(30)]
        public required string NameMiddle { get; set; }

        // Last name of the lead (varchar(30) NOT NULL)
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(30)]
        public required string NameLast { get; set; }

        // Email address of the lead (varchar(80) NOT NULL)
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(80)]
        public required string Email { get; set; }

        // Phone number of the lead (varchar(10) NOT NULL)
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(10)]
        public required string Phone { get; set; }

        // Country code (varchar(3) NOT NULL)
        [Required(ErrorMessage = "Country is required")]
        [StringLength(3)]
        public required string Country { get; set; }

        // State or province code (varchar(2) NOT NULL)
        [Required(ErrorMessage = "State/Province is required")]
        [StringLength(2)]
        public required string StateProvince { get; set; }

        // City name (varchar(40) NOT NULL)
        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public required string City { get; set; }

        // Postal code (varchar(10) NOT NULL)
        [Required(ErrorMessage = "Postal code is required")]
        [StringLength(10)]
        public required string Postal { get; set; }

        // Street address (varchar(50) NOT NULL)
        [Required(ErrorMessage = "Street address is required")]
        [StringLength(50)]
        public required string Street { get; set; }

        // Organization name (varchar(80) NOT NULL)
        [Required(ErrorMessage = "Organization name is required")]
        [StringLength(80)]
        public required string OrganizationName { get; set; }

        // Organization title (varchar(80) NOT NULL)
        [Required(ErrorMessage = "Organization title is required")]
        [StringLength(80)]
        public required string OrganizationTitle { get; set; }

        // Originator fee rate (decimal(9,4) NOT NULL)
        [Required]
        [Column(TypeName = "decimal(9,4)")]
        public decimal OriginatorFeeRate { get; set; }

        // Originator fee fixed (money NOT NULL)
        [Required]
        [Column(TypeName = "money")]
        public decimal OriginatorFeeFixed { get; set; }

        // Flag for Do Not Market (bit NOT NULL)
        [Required]
        public bool DoNotMarket { get; set; }

        // Flag for Do Not Contact (bit NOT NULL)
        [Required]
        public bool DoNotContact { get; set; }

        // Tracking information (varchar(80) NOT NULL)
        [Required(ErrorMessage = "Tracking information is required")]
        [StringLength(80)]
        public required string Tracking { get; set; }

        // Additional comments (varchar(2048))
        [StringLength(2048)]
        public string? Comments { get; set; }

        // Additional notes (varchar(2048))
        [StringLength(2048)]
        public string? Notes { get; set; }
    }

}
