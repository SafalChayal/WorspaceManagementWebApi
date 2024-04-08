using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.DataAccessLayer.Interfaces
{
    public interface IDeskBooking
    {
        IEnumerable<DeskBooking> GetAllDbooking();
        DeskBooking GetDbooking(int id);
        DeskBooking BookDesk(DeskBooking db);
        DeskBooking UpdateDbookingDetail(DeskBooking db, int id);
        DeskBooking DeleteBooking(int id);
    }
}
