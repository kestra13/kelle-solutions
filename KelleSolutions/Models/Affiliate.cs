using System;
using System.ComponentModel.DataAnnotations;

namespace KelleSolutions.Models
{
    public class Affiliate
    {
        // Primary key for the Affiliate entity
        public int Id { get; set; }

        // Name of the Affiliate
        [Required(ErrorMessage = "Name is required")]
        public string ? Name { get; set; }

        // Description of the Affiliate
        [Required(ErrorMessage = "Description is required")]
        public string ? Description { get; set; }

        // Date when the affiliate was created
        public DateTime CreatedDate { get; set; }
    }
}
