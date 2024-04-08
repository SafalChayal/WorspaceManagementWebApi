using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.DataAccessLayer.Interfaces
{
    public interface IRoomDetail
    {
        IEnumerable<RoomDetail> GetAllRooms();
        RoomDetail GetRoomDetail(int id);
        RoomDetail AddRoom(RoomDetail rd);
        RoomDetail UpdateRoomDetail(RoomDetail rd, int id);
        RoomDetail DeleteRoom(int id);
    }
}
