using Microsoft.AspNetCore.Mvc;
using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomDetailService _roomDetailService;

        public RoomController(IRoomDetailService roomDetailService)
        {
            _roomDetailService = roomDetailService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomDetail>> GetAllRooms()
        {
            var roomDetails = _roomDetailService.GetAllRooms();
            if (roomDetails == null)
            {
                return NotFound();
            }
            return Ok(roomDetails);
        }

        [HttpGet("{id}")]
        public ActionResult<RoomDetail> GetRoomDetailById(int id)
        {
            var roomDetail = _roomDetailService.GetRoomDetail(id);
            if (roomDetail == null)
            {
                return NotFound();
            }
            return Ok(roomDetail);
        }

        [HttpPost]
        public ActionResult<RoomDetail> AddRoom(RoomDetail roomDetail)
        {
            var addedRoom = _roomDetailService.AddRoom(roomDetail);
            if (addedRoom == null)
            {
                return BadRequest();
            }
            return Ok(addedRoom);
        }

        [HttpPut("{id}")]
        public ActionResult<RoomDetail> UpdateRoomDetail(int id, RoomDetail roomDetail)
        {
            var updatedRoom = _roomDetailService.UpdateRoomDetail(roomDetail, id);
            if (updatedRoom == null)
            {
                return NotFound();
            }
            return Ok(updatedRoom);
        }

        [HttpDelete("{id}")]
        public ActionResult<RoomDetail> DeleteRoom(int id)
        {
            var deletedRoom = _roomDetailService.DeleteRoom(id);
            if (deletedRoom == null)
            {
                return NotFound();
            }
            return Ok(deletedRoom);
        }
        [HttpGet("RoomDetailByLocation")]
        public ActionResult<RoomDetail> GetRoomByLocation(string locationName)
        {
            var roomDetail=_roomDetailService.GetConferenceByLocation(locationName);
            if (roomDetail == null)
            {
                return NotFound($"No Room Found With Location {locationName}");
            }
            return Ok(roomDetail);
        }
    }
}
