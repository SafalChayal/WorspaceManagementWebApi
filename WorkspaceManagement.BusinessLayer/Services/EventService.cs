using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.CustomException;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.Services
{
    public class EventService:IEventService
    {
        private readonly IEvent eventRepository;

        public EventService(IEvent eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public IEnumerable<Events> GetAllEvents()
        {
            try
            {
                return eventRepository.GetAllEvents();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Events GetEvent(int id)
        {
            try
            {
                return eventRepository.GetEvent(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Events AddEvent(Events e)
        {
            try
            {
                return eventRepository.AddEvent(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Events UpdateEvent(Events e, int id)
        {
            try
            {
                return eventRepository.UpdateEvent(e, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Events DeleteEvent(int id)
        {
            try
            {
                return eventRepository.DeleteEvent(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }
        public IEnumerable<Events> GetEventsByLocation(string locationName)
        {
            var events = eventRepository.GetAllEvents()
                        .Where(e => e.Location?.City?.ToLower() == locationName.ToLower())
                        .ToList();
            if (events == null)
            {
                throw new Exception ($"No Events found In {locationName}");
            }
            return (events);
        }

    }
}
