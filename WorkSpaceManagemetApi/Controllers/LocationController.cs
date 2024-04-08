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
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetAllLocations()
        {
            var locations = _locationService.GetAllLocation();
            if (locations == null)
            {
                return NotFound();
            }
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public ActionResult<Location> GetLocationById(int id)
        {
            var location = _locationService.GetLocation(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpPost]
        public ActionResult<Location> AddLocation(Location location)
        {
            var addedLocation = _locationService.AddLocation(location);
            if (addedLocation == null)
            {
                return BadRequest();
            }
            return Ok(addedLocation);
        }

        [HttpPut("{id}")]
        public ActionResult<Location> UpdateLocation(int id, Location location)
        {
            var updatedLocation = _locationService.UpdateLocation(location, id);
            if (updatedLocation == null)
            {
                return NotFound();
            }
            return Ok(updatedLocation);
        }

        [HttpDelete("{id}")]
        public ActionResult<Location> DeleteLocation(int id)
        {
            var deletedLocation = _locationService.DeleteLocation(id);
            if (deletedLocation == null)
            {
                return NotFound();
            }
            return Ok(deletedLocation);
        }

    }
}
