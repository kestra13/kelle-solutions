using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    public class PageAccess
    {
        [Key]
        [Required]
        public int PageAccessID { get; set; }

        [MaxLength(12)]
        [Required]
        public string PageAccessName { get; set; } = null!;
        // TODO: dotnet ef migrations add RolePermissionGroupEntity
        // command doesnt work until PageAccess table is implemented
    }
}