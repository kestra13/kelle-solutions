using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }

        [Required]
        [MaxLength(50)]  // Updated from 6 to 50 to match ERD
        public string RoleName { get; set; } = null!;

        // Navigation property for User relationship
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
