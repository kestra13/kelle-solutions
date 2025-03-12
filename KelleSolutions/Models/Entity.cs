using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    public class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }  // Primary Key

        public bool Archived { get; set; } = false;

        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime Updated { get; set; } = DateTime.UtcNow;

        public short? Operator { get; set; }  // Nullable

        [Required]
        public short Team { get; set; }

        public byte? Visibility { get; set; }  // Nullable

        [Required]
        public short Category { get; set; }

        public short? MySource { get; set; }  // Nullable

        [Required, StringLength(80)]
        public string EntityName { get; set; } = string.Empty;

        [StringLength(80)]
        public string? Name_Display { get; set; }  // Nullable

        [StringLength(80)]
        public string? Headline { get; set; }  // Nullable

        [Required, StringLength(10)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(10)]
        public string? Phone_Secondary { get; set; }  // Nullable

        [StringLength(20)]
        public string? Phone_Primary_Label { get; set; }  // Nullable

        [StringLength(20)]
        public string? Phone_Secondary_Label { get; set; }  // Nullable

        [Required, StringLength(3)]
        public string Country { get; set; } = string.Empty;

        [Required, StringLength(2)]
        public string StateProvince { get; set; } = string.Empty;

        [Required, StringLength(40)]
        public string City { get; set; } = string.Empty;

        [Required, StringLength(10)]
        public string Postal { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Street { get; set; } = string.Empty;

        public bool DoNot_Market { get; set; } = false;
        public bool DoNot_Contact { get; set; } = false;

        [StringLength(2048)]
        public string? Tracking { get; set; }  // Nullable

        [StringLength(2048)]
        public string? Comments { get; set; }  // Nullable

        [StringLength(2048)]
        public string? Website { get; set; }  // Nullable

        [StringLength(int.MaxValue)]
        public string? Bio { get; set; }  // Nullable
    }
}
