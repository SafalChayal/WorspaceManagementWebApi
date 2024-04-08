using System.ComponentModel.DataAnnotations;

namespace WorkspaceManagement.DataAccessLayer.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        [Required]
        public string? DeptName { get; set; }
        public ICollection<Employee> ?Employees { get; set; }
    }
}
