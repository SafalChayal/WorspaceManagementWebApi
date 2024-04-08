using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.CustomException;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.Services
{
    public class RoomBookingService:IRoomBookingService 
    {
        private readonly IRoomBooking roomBookingRepository;

        public RoomBookingService(IRoomBooking roomBookingRepository)
        {
            this.roomBookingRepository = roomBookingRepository;
        }

        public IEnumerable<RoomBooking> GetAllRbooking()
        {
            try
            {
                return roomBookingRepository.GetAllRbooking();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public RoomBooking GetRbooking(int id)
        {
            try
            {
                return roomBookingRepository.GetRbooking(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public RoomBooking BookRoom(RoomBooking db)
        {
            try
            {
                return roomBookingRepository.BookRoom(db);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public RoomBooking UpdateRbookingDetail(RoomBooking db, int id)
        {
            try
            {
                return roomBookingRepository.UpdateRbookingDetail(db, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public RoomBooking DeleteBooking(int id)
        {
            try
            {
                return roomBookingRepository.DeleteBooking(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }
        public IEnumerable<RoomBooking> GetRoomBookingByLocation(string locationName)
        {
            var bookings = roomBookingRepository.GetAllRbooking()
                           .Where(e => e.RoomDetail?.Location?.City?.ToLower() == locationName.ToLower())
                           .ToList();
            if (bookings == null)
            {
                throw new Exception($"No Booking found In {locationName}");
            }
            return (bookings);
        }

    }
}
