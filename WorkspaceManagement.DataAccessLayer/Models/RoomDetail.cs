using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkspaceManagement.DataAccessLayer.Models
{
    public class RoomDetail
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public string ?RoomName { get; set; }
        [Required]
        public int ?RoomCapacity { get; set; }  
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [Required]
        public string? ImageData { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public string? Amenities { get; set; }
        public Location? Location { get; set; }
    }
}
