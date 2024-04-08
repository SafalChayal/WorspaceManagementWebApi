using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.DataAccessLayer.Interfaces
{
    public interface IRoomBooking
    {
        IEnumerable<RoomBooking> GetAllRbooking();
        RoomBooking GetRbooking(int id);
        RoomBooking BookRoom(RoomBooking db);
        RoomBooking UpdateRbookingDetail(RoomBooking db, int id);
        RoomBooking DeleteBooking(int id);
    }
}
