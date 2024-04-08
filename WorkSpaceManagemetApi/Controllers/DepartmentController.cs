using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService ideptSer;
        public DepartmentController(IDepartmentService ideptSer)
        {
            this.ideptSer = ideptSer;
        }
        [HttpGet]
        public ActionResult  GetAllDepartment()
        {
            var dept = ideptSer.GetAllDepartments();
            if (dept != null)
            {
                return Ok(dept);
            }
            return NotFound("No Dept Found");

        }
        [HttpPost]
        public ActionResult AddDepartment(Department ta)
        {
             ideptSer.AddDepartment(ta);
            return Ok(ta);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateDepartment(Department ta, int id)
        {
            var dept = ideptSer.UpdateDepartment(ta,id);
            if (dept != null)
            {

                return (Ok(dept));
            }
            return BadRequest($"Department Not found With Id={id}");

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteDepartment(int id)
        {
            var dept =  ideptSer.DeleteDepartment(id);
            if (dept == null)
            {
                return BadRequest($"Department Not found With Id={id}");
            }
         
            return Ok(dept);
        }
        [HttpGet("{id}")]
        public ActionResult GetDepartment(int id)
        {
            var dept = ideptSer.GetDepartment(id);
            if (dept == null)
            {
                return BadRequest($"Department Not found With Id={id}");

            }
            return Ok(dept);
        }
    }
}
