using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.CustomException;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkspaceManagement.BusinessLayer.Services
{
    public class NotificationService:INotificationService
    {
        private readonly INotification notificationRepository;

        public NotificationService(INotification notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }

        public IEnumerable<Notification> GetAllNotification()
        {
            try
            {
                return notificationRepository.GetAllNotification();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Notification GetNotification(int id)
        {
            try
            {
                return notificationRepository.GetNotification(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Notification AddNotification(Notification notification)
        {
            try
            {
                return notificationRepository.AddNotification(notification);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Notification UpdateNotification(Notification notification, int id)
        {
            try
            {
                return notificationRepository.UpdateNotification(notification, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Notification DeleteNotification(int id)
        {
            try
            {
                return notificationRepository.DeleteNotification(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }
        public IEnumerable<Notification> GetNotificationByLocation(string locationName)
        {
            var notifications =   notificationRepository.GetAllNotification()
                          .Where(e => e.Location?.City?.ToLower() == locationName.ToLower())
                          .ToList();
            if (notifications == null)
            {
                throw new Exception($"No Notification found In {locationName}");
            }
            return (notifications);
        }

    }
}
