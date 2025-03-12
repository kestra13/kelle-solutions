using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    public class PermissionGroup
    {
        [Key]
        [Required]
        public int PermissionGroupID { get; set; }

        [Required]
        public int PermissionID { get; set; }

        [MaxLength(15)]
        [Required]
        public string GroupName { get; set; } = null!;

        public int? ParentGroupID { get; set; }

        [ForeignKey("ParentGroupID")]
        public virtual PermissionGroup ParentGroup { get; set; }

        [ForeignKey("PermissionID")]
        public virtual Permission Permission { get; set; } = null!;

        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; } = DateTime.UtcNow;

        // Navigation Property for Child Groups
        public virtual ICollection<PermissionGroup> ChildGroups { get; set; } = new List<PermissionGroup>();

        public void AddChildGroup(PermissionGroup childGroup)
        {
            if (ChildGroups == null)
                ChildGroups = new List<PermissionGroup>();

            ChildGroups.Add(childGroup);
        }
    }
}