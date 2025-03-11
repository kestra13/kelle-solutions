using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    public class RolePermissionGroupEntity
    {
        // Primary Key
        [Key]
        [Required]
        public int RoleID { get; set; }

        // Primary Key
        [Key]
        [Required]
        public int PermissionGroupID { get; set; }

        // Primary Key
        [Key]
        [Required]
        public int PageAccessID { get; set; }

        // Foreign Keys
        public virtual Role RoleNavigation { get; set; } = null!;
        public virtual PermissionGroup PermissionGroupNavigation { get; set; } = null!;
        public virtual PageAccess PageAccess { get; set; } = null!;
    }
}
