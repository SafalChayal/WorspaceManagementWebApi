using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.DataAccessLayer.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee, int id);
        Employee DeleteEmployee(int id);
    }
}
