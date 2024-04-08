using Microsoft.AspNetCore.Mvc;
using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.Models;
namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskBookingController : ControllerBase
    {
        private readonly IDeskBookingService _deskBookingService;

        public DeskBookingController(IDeskBookingService deskBookingService)
        {
            _deskBookingService = deskBookingService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DeskBooking>> GetAllDbookings()
        {
            var deskBookings = _deskBookingService.GetAllDbooking();
            if (deskBookings == null)
            {
                return NotFound();
            }
            return Ok(deskBookings);
        }

        [HttpGet("{id}")]
        public ActionResult<DeskBooking> GetDbookingById(int id)
        {
            var deskBooking = _deskBookingService.GetDbooking(id);
            if (deskBooking == null)
            {
                return NotFound();
            }
            return Ok(deskBooking);
        }

        [HttpPost]
        public ActionResult<DeskBooking> BookDesk(DeskBooking deskBooking)
        {
            var bookedDesk = _deskBookingService.BookDesk(deskBooking);
            if (bookedDesk == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetDbookingById), new { id = bookedDesk.BookingId }, bookedDesk);
        }

        [HttpPut("{id}")]
        public ActionResult<DeskBooking> UpdateDbookingDetail(int id, DeskBooking deskBooking)
        {
            var updatedDeskBooking = _deskBookingService.UpdateDbookingDetail(deskBooking, id);
            if (updatedDeskBooking == null)
            {
                return NotFound();
            }
            return Ok(updatedDeskBooking);
        }

        [HttpDelete("{id}")]
        public ActionResult<DeskBooking> DeleteBooking(int id)
        {
            var deletedBooking = _deskBookingService.DeleteBooking(id);
            if (deletedBooking == null)
            {
                return NotFound();
            }
            return Ok(deletedBooking);
        }

    }
}
