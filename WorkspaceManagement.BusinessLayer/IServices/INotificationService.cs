using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.IServices
{
    public interface INotificationService
    {
        IEnumerable<Notification> GetAllNotification();
        Notification GetNotification(int id);
        Notification AddNotification(Notification loc);
        Notification UpdateNotification(Notification loc, int id);
        Notification DeleteNotification(int id);
        IEnumerable<Notification> GetNotificationByLocation(string locationName);
    }
}
