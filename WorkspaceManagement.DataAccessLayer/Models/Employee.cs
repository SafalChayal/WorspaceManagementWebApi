using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace WorkspaceManagement.DataAccessLayer.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string? Fname { get; set; }
        [Required]
        public string? Lname { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [ForeignKey("Department")]
        public int DepId { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? AddPassword { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? ImageData { get; set; } 
        public Department? Department { get; set; }
        public Location ?Location { get; set; } 
    }
}
