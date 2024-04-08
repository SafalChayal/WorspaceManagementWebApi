using Microsoft.EntityFrameworkCore;
using WorkspaceManagement.DataAccessLayer.Data;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;


namespace WorkSpaceManagemetApi.Repository
{
    public class DepartmentRepository:IDepartment
    {
        private readonly WorkSpaceDbContext _dbContext;

        public DepartmentRepository(WorkSpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            try
            {
                return await _dbContext.Department.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Department> GetDepartment(int id)
        {
            try
            {
                var department = await _dbContext.Department.FindAsync(id);
                if(department!= null)
                {
                   return department;
                }
                return new Department();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Department AddDepartment(Department db)
        {
            try
            {
                _dbContext.Department.Add(db);
                _dbContext.SaveChanges();
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public Department UpdateDepartment(Department db, int id)
        {
            try
            {
                var existingDeparment = _dbContext.Department.Find(id);
                if (existingDeparment == null)
                {
                    throw new InvalidOperationException();
                }
                existingDeparment.DeptName = db.DeptName;
                _dbContext.SaveChanges();
                return existingDeparment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public Department DeleteDepartment(int id)
        {
            try
            {
                var dept = _dbContext.Department.Find(id);
                if (dept == null)
                {
                    throw new Exception();
                }
                _dbContext.Department.Remove(dept);
                _dbContext.SaveChanges();
                return dept;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);

            }
        }
    }
}
