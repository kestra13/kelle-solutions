using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KelleSolutions.Models; // Ensure this is present

namespace KelleSolutions.Models
{
    public class PersonToListing
    {
        [Key]
        public int Code { get; set; } // Primary Key

        // Foreign Keys
        public int PersonId { get; set; }
        public int ListingId { get; set; }

        // Navigation Properties
        public Person Person { get; set; }
        public Listing Listing { get; set; }
    }
}