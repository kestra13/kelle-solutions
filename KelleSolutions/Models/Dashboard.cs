using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KelleSolutions.Models
{
    public class Dashboard
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public string Title { get; set; } = "My Dashboard"; // Default title, can be changed

        // Foreign Key - One Dashboard per User
        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        //List of widget that would be on a Dashboard
        //public virtual ICollection<DashboardWidget> Widgets { get; set; } = new List<DashboardWidget>();
    }
}
