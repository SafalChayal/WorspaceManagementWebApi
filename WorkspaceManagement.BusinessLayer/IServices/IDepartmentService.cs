using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.IServices
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartment(int id);
        Department AddDepartment(Department e);
        Department UpdateDepartment(Department e, int id);
        Department DeleteDepartment(int id);
    }
}
