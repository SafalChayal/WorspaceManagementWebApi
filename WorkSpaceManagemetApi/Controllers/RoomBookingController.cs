using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;
namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBookingController : ControllerBase
    {
        private readonly IRoomBookingService _roomBookingService;

        public RoomBookingController(IRoomBookingService roomBookingService)
        {
            _roomBookingService = roomBookingService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomBooking>> GetAllRbookings()
        {
            var roomBookings = _roomBookingService.GetAllRbooking();
            if (roomBookings == null)
            {
                return NotFound();
            }
            return Ok(roomBookings);
        }

        [HttpGet("{id}")]
        public ActionResult<RoomBooking> GetRbookingById(int id)
        {
            var roomBooking = _roomBookingService.GetRbooking(id);
            if (roomBooking == null)
            {
                return NotFound();
            }
            return Ok(roomBooking);
        }

        [HttpPost]
        public ActionResult<RoomBooking> BookRoom(RoomBooking roomBooking)
        {
            var bookedRoom = _roomBookingService.BookRoom(roomBooking);
            if (bookedRoom == null)
            {
                return BadRequest();
            }
            return Ok(bookedRoom);
        }

        [HttpPut("{id}")]
        public ActionResult<RoomBooking> UpdateRbookingDetail(int id, RoomBooking roomBooking)
        {
            var updatedRoomBooking = _roomBookingService.UpdateRbookingDetail(roomBooking, id);
            if (updatedRoomBooking == null)
            {
                return NotFound();
            }
            return Ok(updatedRoomBooking);
        }

        [HttpDelete("{id}")]
        public ActionResult<RoomBooking> DeleteBooking(int id)
        {
            var deletedBooking = _roomBookingService.DeleteBooking(id);
            if (deletedBooking == null)
            {
                return NotFound();
            }
            return Ok(deletedBooking);
        }
        [HttpGet("RoomBookingByLocation")]
        public ActionResult<RoomBooking> GetRoomBookingByLocation(string locationName)
        {
            var roomBooking = _roomBookingService.GetRoomBookingByLocation(locationName);
            if (roomBooking == null)
            {
                return NotFound($"No RoomBooking Found With Location {locationName}");
            }
            return Ok(roomBooking);
        }

    }
}
