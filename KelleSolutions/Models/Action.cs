using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models {
    // Defines the Leads entity and its properties (ex: "LeadID", "LeadName", etc.)
    public class ActionEntity {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// Unique ID for each action (PK)
        public int ActionID { get; set; }

        [Required(ErrorMessage = "Action title is required")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Operator is required")]
        public required int Operator { get; set; }

        /*[Required(ErrorMessage = "Team is required")]*/
        public /*required*/ int Team { get; set; }
        
        //[Required(ErrorMessage = "Visibility is required")]
        public /*required*/ VisibilityLevel? Visibility { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public required string Category { get; set; }

        public string? Tag { get; set; }

        [Required(ErrorMessage = "Due Date is required")]
        public required DateTime Due { get; set; }

        public string? Relation { get; set; }

        public bool Important { get; set; }

        public string? Comments { get; set; }
    }
}


public enum VisibilityLevel
{
    None = 0,
    Operator = 1,        // 0000
    Broker = 2,      // 0001
    Public = 4,       // 0010
}

/*public enum CategoryType
{
    None = 0,
    [Description("Send Email")]
    sendEmail = 1
}*/