using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.IServices
{
    public interface IRoomDetailService
    {
        IEnumerable<RoomDetail> GetAllRooms();
        RoomDetail GetRoomDetail(int id);
        RoomDetail AddRoom(RoomDetail rd);
        RoomDetail UpdateRoomDetail(RoomDetail rd, int id);
        RoomDetail DeleteRoom(int id);
       IEnumerable<RoomDetail> GetConferenceByLocation(string locationName);

    }
}
