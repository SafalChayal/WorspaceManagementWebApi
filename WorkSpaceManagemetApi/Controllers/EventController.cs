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
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Events>> GetAllEvents()
        {                                                                           
            var events = _eventService.GetAllEvents();
            if (events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        [HttpGet("{id}")]
        public ActionResult<Events> GetEventById(int id)
        {
            var evnt = _eventService.GetEvent(id);
            if (evnt == null)
            {
                return NotFound();
            }
            return Ok(evnt);
        }

        [HttpPost]
        public ActionResult<Events> AddEvent(Events evnt)
        {
            var addedEvent = _eventService.AddEvent(evnt);
            if (addedEvent == null)
            {
                return BadRequest();
            }
            return Ok(addedEvent);
        }

        [HttpPut("{id}")]
        public ActionResult<Events> UpdateEvent(int id, Events evnt)
        {
            var updatedEvent = _eventService.UpdateEvent(evnt, id);
            if (updatedEvent == null)
            {
                return NotFound();
            }
            return Ok(updatedEvent);
        }

        [HttpDelete("{id}")]
        public ActionResult<Events> DeleteEvent(int id)
        {
            var deletedEvent = _eventService.DeleteEvent(id);
            if (deletedEvent == null)
            {
                return NotFound();
            }
            return Ok(deletedEvent);
        }
        [HttpGet("EventByLocation")]
        public ActionResult<Events> GetEventsByLocation(string locationName)
        {
            var events=_eventService.GetEventsByLocation(locationName);
            if(events == null)
            {
                return NotFound($"No Event Found with LocationName {locationName}");
            }
            return Ok(events);
        }

    }
}
