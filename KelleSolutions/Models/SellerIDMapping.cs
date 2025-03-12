// Updated: 03/11/2025

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    // defines the relationship between a Person (seller) and Property
    public class SellerIDMapping
    {
        // unique identifier for each seller-property relationship
        [Key]
        public int Code { get; set; }
        
        // foreign key reference to Person.cs (the seller)
        [Required]
        public int PersonID { get; set; }
        
        // foreign key reference to Property.cs (the property being sold)
        [Required]
        public int PropertyID { get; set; }
        
        // date when the relationship began (listing date)
        [Required]
        public DateTime StartDate { get; set; }
        
        // optional date when the relationship ended (sold date, withdrawn date)
        public DateTime? EndDate { get; set; }
        
        // indicates if this relationship is currently active
        [Required]
        public bool IsActive { get; set; }
        
        // timestamp when this record was created
        [Required]
        public DateTime Created { get; set; }
        
        // timestamp when this record was last updated
        [Required]
        public DateTime Updated { get; set; }
        
        // additional information about this relationship
        [StringLength(255)]
        public string Notes { get; set; }
        
        // navigation properties for entity relationships
        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
        
        [ForeignKey("PropertyID")]
        public virtual Property Property { get; set; }
    }
}