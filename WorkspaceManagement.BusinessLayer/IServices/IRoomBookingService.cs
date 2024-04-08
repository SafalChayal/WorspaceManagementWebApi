using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.IServices
{
    public interface IRoomBookingService
    {
        IEnumerable<RoomBooking> GetAllRbooking();
        RoomBooking GetRbooking(int id);
        RoomBooking BookRoom(RoomBooking db);
        RoomBooking UpdateRbookingDetail(RoomBooking db, int id);
        RoomBooking DeleteBooking(int id);
        IEnumerable<RoomBooking> GetRoomBookingByLocation(string locationName);

    }
}
