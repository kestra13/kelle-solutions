// Updated: 03/11/2025

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    // defines a centralized mapping for status values used across the system
    public class StatusMapping
    {
        // unique identifier for each status mapping
        [Key]
        public int Code { get; set; }
        
        // the type of entity this status applies to (e.g., "Listing", "Lead", "Property")
        [Required]
        [StringLength(50)]
        public string EntityType { get; set; }
        
        // code representing the status
        [Required]
        public short StatusCode { get; set; }
        
        // readable name of the status
        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }
        
        // optional description explaining this status
        [StringLength(255)]
        public string Description { get; set; }
        
        // hex color code for UI presentation
        [StringLength(7)]
        public string ColorCode { get; set; }
        
        // order for display in UI dropdowns and lists
        public int? DisplayOrder { get; set; }
        
        // timestamp when this record was created
        [Required]
        public DateTime Created { get; set; }
        
        // timestamp when this record was last updated
        [Required]
        public DateTime Updated { get; set; }
    }
}