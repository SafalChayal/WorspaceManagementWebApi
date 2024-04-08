using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.DataAccessLayer.Interfaces
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartment(int id);
        Department AddDepartment(Department e);
        Department UpdateDepartment(Department e, int id);
        Department DeleteDepartment(int id);
    }
}
