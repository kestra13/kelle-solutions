using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

<<<<<<< HEAD
namespace KelleSolutions.Models {
    public class Person {
        // Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }

        // Indicates if the record is archived
        public bool Archived { get; set; }

        // Timestamp when the record was created
        [Column(TypeName = "datetime2")]
        public DateTime? Created { get; set; }  // Made nullable

        // Timestamp when the record was last updated
        [Column(TypeName = "datetime2")]
        public DateTime? Updated { get; set; }  // Made nullable

        // Operator reference
        public short? Operator { get; set; }  // Made nullable

        // Team reference
        [ForeignKey("Team")]
        public short? Team { get; set; }  // Made nullable

        // Visibility settings
        public byte? Visibility { get; set; }  // Made nullable

        // Category of the person
        [ForeignKey("CategoryId")]
        public short? CategoryId { get; set; }  // Made nullable

        // Source of the person
        public short? MySource { get; set; }  // Made nullable

        // Verification status
        public bool Verified { get; set; }

        // VIP status
        public bool VIP { get; set; }

        // First name (Required)
        [Required(ErrorMessage = "First Name is required")]
        [Column(TypeName = "nvarchar(30)")]
        public string Name_First { get; set; } = string.Empty;

        // Middle name (Optional)
        [Column(TypeName = "nvarchar(30)")]
        public string? Name_Middle { get; set; }

        // Last name (Required)
        [Required(ErrorMessage = "Last Name is required")]
        [Column(TypeName = "nvarchar(30)")]
        public string Name_Last { get; set; } = string.Empty;

        // Display name (Optional)
        [Column(TypeName = "nvarchar(92)")]
        public string? Name_Display { get; set; }  // Made nullable

        // Headline (Optional)
        [Column(TypeName = "nvarchar(80)")]
        public string? Headline { get; set; }  // Made nullable

        // Primary Email (Required)
        [Required(ErrorMessage = "Primary Email is required")]
        [Column(TypeName = "nvarchar(80)")]
        [EmailAddress]
        public string Email_Primary { get; set; } = string.Empty;

        // Secondary Email (Optional)
        [Column(TypeName = "nvarchar(80)")]
        [EmailAddress]
        public string? Email_Secondary { get; set; }

        // Email Labels (Optional)
        [Column(TypeName = "nvarchar(20)")]
        public string? Email_Primary_Label { get; set; }  // Made nullable

        [Column(TypeName = "nvarchar(20)")]
        public string? Email_Secondary_Label { get; set; }  // Made nullable

        // Primary Phone (Required)
        [Required(ErrorMessage = "Primary Phone is required")]
        [Column(TypeName = "nvarchar(10)")]
        [Phone]
        public string Phone_Primary { get; set; } = string.Empty;

        // Secondary Phone (Optional)
        [Column(TypeName = "nvarchar(10)")]
        [Phone]
        public string? Phone_Secondary { get; set; }

        // Phone Labels (Optional)
        [Column(TypeName = "nvarchar(20)")]
        public string? Phone_Primary_Label { get; set; }  // Made nullable

        [Column(TypeName = "nvarchar(20)")]
        public string? Phone_Secondary_Label { get; set; }  // Made nullable

        // Address Information (Optional)
        [Column(TypeName = "nvarchar(3)")]
        public string? Country { get; set; }  // Made nullable

        [Column(TypeName = "nvarchar(2)")]
        public string? StateProvince { get; set; }  // Made nullable

        [Column(TypeName = "nvarchar(40)")]
        public string? City { get; set; }  // Made nullable

        [Column(TypeName = "nvarchar(10)")]
        public string? Postal { get; set; }  // Made nullable

        [Column(TypeName = "nvarchar(50)")]
        public string? Street { get; set; }  // Made nullable

        // Marketing and Contact Preferences
        public bool DoNot_Market { get; set; }
        public bool DoNot_Contact { get; set; }

        // Tracking info (Optional)
        [Column(TypeName = "nvarchar(80)")]
        public string? Tracking { get; set; }

        // Comments (Optional)
        [Column(TypeName = "nvarchar(2048)")]
        public string? Comments { get; set; }

        // Bio (Optional)
        [Column(TypeName = "nvarchar(max)")]
        public string? Bio { get; set; }

        // Navigation property
        public virtual Team? TeamNavigation { get; set; }

        // Category Property
        public virtual Category? Category { get; set; }
=======
namespace KelleSolutions.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime Created { get; set; }
        public string? OperatorName { get; set; }
        public ICollection<PersonToPerson> PersonToPeople { get; set; } = new List<PersonToPerson>();
        public ICollection<PersonToProperties> TenantToPeople { get; set; } = new List<PersonToProperties>();
        public ICollection<PersonToListing> PersonToListing { get; set; }
>>>>>>> ac7a374014d444c8b4faf860756d2f65e15f04fa
    }
}
