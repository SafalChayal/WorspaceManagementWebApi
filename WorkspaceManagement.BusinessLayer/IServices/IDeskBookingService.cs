using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.IServices
{
    public interface IDeskBookingService
    {
        IEnumerable<DeskBooking> GetAllDbooking();
        DeskBooking GetDbooking(int id);
        DeskBooking BookDesk(DeskBooking db);
        DeskBooking UpdateDbookingDetail(DeskBooking db, int id);
        DeskBooking DeleteBooking(int id);
    }
}
