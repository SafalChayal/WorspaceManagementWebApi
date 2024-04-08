using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.CustomException;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace WorkspaceManagement.BusinessLayer.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployee employeeRepository;
        public EmployeeService(IEmployee employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
                return employeeRepository.GetAllEmployee();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }
        public Employee GetEmployee(int id)
        {
            try
            {
                return employeeRepository.GetEmployee(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }
        public Employee AddEmployee(Employee employee)
        {
            try
            {
                return employeeRepository.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }
        public Employee UpdateEmployee(Employee employee, int id)
        {
            try
            {
                return employeeRepository.UpdateEmployee(employee, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }
        public Employee DeleteEmployee(int id)
        {
            try
            {
                return employeeRepository.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }
        public IEnumerable<Employee> GetEmployeesByLocation(string locationName)
        {
            var employees =  employeeRepository.GetAllEmployee().Where(x => (x.Location ?? new Location()).City == locationName).ToList();
            if (employees == null)
            {
                throw new Exception($"No Employee Found With LocationName {locationName}");
            }
            return employees;
        }
    }
}
