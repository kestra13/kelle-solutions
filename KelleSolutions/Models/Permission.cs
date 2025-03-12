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
        public PermissionResourceType ResourceType { get; set; }

        [Required]
        public PermissionAction Action { get; set; }

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

        // Updates the permission details (tracking the update timestamp and user).
        public void UpdatePermission(string newName, PermissionAction newAction, bool isAllowed, int updatedBy)
        {
            Name = newName;
            Action = newAction;
            IsAllowed = isAllowed;
            Updated = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }
    }

    // Define resource types that permissions apply to
    public enum PermissionResourceType
    {
        User,
        Listing,
        Transaction
    }

    public enum PermissionAction
    {
        Read,
        Update,
        Delete
    }
}