using WorkspaceManagement.DataAccessLayer.Models;
namespace WorkspaceManagement.BusinessLayer.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee, int id);
        Employee DeleteEmployee(int id);
        IEnumerable<Employee> GetEmployeesByLocation(string locationName);    
    }
}
