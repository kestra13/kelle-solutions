using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    public class Permission
    {
        [Key]
        [Required]
        public int PermissionID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string ResourceType { get; set; }

        [Required]
        [StringLength(50)]
        public string Action { get; set; }

        [Required]
        public bool IsAllowed { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Updated { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        // track who created/modified this permission
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}