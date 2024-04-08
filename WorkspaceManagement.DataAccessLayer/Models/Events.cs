using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkspaceManagement.DataAccessLayer.Models
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public string? ImageData { get; set; }
        [Required]
        public string? EventTitle { get; set; }
        [Required]
        [StringLength(200,MinimumLength =5)]
        public string? EventDescription { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public Location? Location { get; set; } 
    }
}
