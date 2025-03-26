using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    public class MyPage
    {
        [Required]
        public string ? Name {get; set;}

        [Required]
        public string ? Title {get; set;}

        [Required]
        public int ? LicenseNumber {get; set;}

        [Required]
        [MaxLength(80)]
        public string ? Email {get; set;}

        [Required]
        [MaxLength(10)]
        public string ? PhoneNumber {get; set;}
    }
}