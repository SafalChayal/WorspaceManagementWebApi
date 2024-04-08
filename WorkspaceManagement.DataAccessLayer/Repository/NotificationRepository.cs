using Microsoft.EntityFrameworkCore;
using WorkspaceManagement.DataAccessLayer.Data;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;
namespace WorkSpaceManagemetApi.Repository
{
    public class NotificationRepository:INotification
    {
        private readonly WorkSpaceDbContext _dbContext;

        public NotificationRepository(WorkSpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Notification> GetAllNotification()
        {
            try
            {
                return _dbContext.Notifications.Include(x=>x.Location).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Notification GetNotification(int id)
        {
            try
            {
                var notification= _dbContext.Notifications.Find(id);
                if(notification == null)
                {
                    throw new Exception();
                }
                return notification;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Notification AddNotification(Notification notification)
        {
            try
            {
                _dbContext.Notifications.Add(notification);
                _dbContext.SaveChanges();
                return notification;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Notification UpdateNotification(Notification notification, int id)
        {
            try
            {
                var existingNotification = _dbContext.Notifications.Find(id);
                if (existingNotification == null)
                {
                    throw new Exception();  
                }
                existingNotification.NotificationSubject = notification.NotificationSubject;
                _dbContext.SaveChanges();
                return existingNotification;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Notification DeleteNotification(int id)
        {
            try
            {
                var notificationToDelete = _dbContext.Notifications.Find(id);
                if (notificationToDelete == null)
                {
                    throw new Exception();
                }
                _dbContext.Notifications.Remove(notificationToDelete);
                _dbContext.SaveChanges();
                return notificationToDelete;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
