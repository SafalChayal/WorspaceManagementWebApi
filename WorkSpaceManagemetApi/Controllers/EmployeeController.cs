using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;
using WorkSpaceManagemetApi.Repository;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployee();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            var addedEmployee = _employeeService.AddEmployee(employee);
            if (addedEmployee == null)
            {
                return BadRequest();
            }
            return Ok(addedEmployee);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, Employee employee)
        {
            var updatedEmployee = _employeeService.UpdateEmployee(employee, id);
            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            var deletedEmployee = _employeeService.DeleteEmployee(id);
            if (deletedEmployee == null)
            {
                return NotFound();
            }
            return Ok(deletedEmployee);
        }
        [HttpGet("EmployeeByLocation")]
        public ActionResult GetEmployeeByLocation(string locationName)
        {
            var employees =_employeeService.GetEmployeesByLocation(locationName);
            if(employees == null)
            {
                return NotFound($"No Employee Found With Location {locationName}");
            }
            return Ok(employees);
        }
    }
}
