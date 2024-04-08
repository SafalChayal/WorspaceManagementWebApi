using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkspaceManagement.DataAccessLayer.Models
{
    public class RoomBooking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public string ?MeetingTitle { get; set; }
        [Required]
        public int NumberOfParticipants { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public string? EmployeeName { get; set; }
        [ForeignKey("RoomDetail")]
        public int RoomId { get; set; }
        public Employee ?Employee { get; set; } 
        public RoomDetail? RoomDetail { get; set; }


    }
}
