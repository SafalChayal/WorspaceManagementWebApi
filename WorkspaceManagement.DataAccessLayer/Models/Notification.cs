using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkspaceManagement.DataAccessLayer.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        [Required]
        public string? NotificationSubject { get; set; }
        [Required]
        public string? Description { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public DateTime? Time { get; set; }
        public Location? Location { get; set; } 
    }
}
