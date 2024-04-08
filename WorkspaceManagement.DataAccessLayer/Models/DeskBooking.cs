using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkspaceManagement.DataAccessLayer.Models
{
    public class DeskBooking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public DateTime? BookingDate { get; set; }
        [Required]
        public DateTime? BookingTime { get; set; }
        [Required]
        public string? EmployeeName { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

    }
}
