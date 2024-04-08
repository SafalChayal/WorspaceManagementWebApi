using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.CustomException;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.Services
{
    public  class DepartmentService:IDepartmentService
    {
        private readonly IDepartment idepartment;

        public DepartmentService(IDepartment idepartment)
        {
            this.idepartment =idepartment ;
        }

        public Task<IEnumerable<Department>> GetAllDepartments()
        {
            try
            {
                return idepartment.GetAllDepartments();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occured",ex);
            }
        }

        public Task<Department> GetDepartment(int id)
        {
            try
            {
                return idepartment.GetDepartment(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occured", ex);
            }
        }

        public Department AddDepartment(Department db)
        {
            try
            {
                return idepartment.AddDepartment(db);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occured", ex);
            }
        }

        public Department UpdateDepartment(Department db, int id)
        {
            try
            {
                return idepartment.UpdateDepartment(db, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occured", ex);
            }
        }

        public Department DeleteDepartment(int id)
        {
            try
            {
                return idepartment.DeleteDepartment(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occured", ex);
            }
        }
    }
}
