using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;
using WorkSpaceManagemetApi.Repository;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Notification>> GetAllNotifications()
        {
            var notifications = _notificationService.GetAllNotification();
            if (notifications == null)
            {
                return NotFound();
            }
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public ActionResult<Notification> GetNotificationById(int id)
        {
            var notification = _notificationService.GetNotification(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpPost]
        public ActionResult<Notification> AddNotification(Notification notification)
        {
            var addedNotification = _notificationService.AddNotification(notification);
            if (addedNotification == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetNotificationById), new { id = addedNotification.NotificationId }, addedNotification);
        }

        [HttpPut("{id}")]
        public ActionResult<Notification> UpdateNotification(int id, Notification notification)
        {
            var updatedNotification = _notificationService.UpdateNotification(notification, id);
            if (updatedNotification == null)
            {
                return NotFound();
            }
            return Ok(updatedNotification);
        }

        [HttpDelete("{id}")]
        public ActionResult<Notification> DeleteNotification(int id)
        {
            var deletedNotification = _notificationService.DeleteNotification(id);
            if (deletedNotification == null)
            {
                return NotFound();
            }
            return Ok(deletedNotification);
        }
        [HttpGet("NotificationByLocation")]
        public ActionResult<Notification> GetNotificationByLocation(string locationName)
        {
            var notification = _notificationService.GetNotificationByLocation(locationName);
            if(notification == null)
            {
                return NotFound($"No Notification Found With LocationName {locationName}");
            }
            return Ok(notification);
        }
    }
}
