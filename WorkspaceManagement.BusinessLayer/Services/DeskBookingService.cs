using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.CustomException;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;
using WorkSpaceManagemetApi.Repository;

namespace WorkspaceManagement.BusinessLayer.Services
{
    public class DeskBookingService:IDeskBookingService
    {

        private readonly IDeskBooking deskBookingRepository;

        public DeskBookingService(IDeskBooking deskBookingRepository)
        {
            this.deskBookingRepository = deskBookingRepository;
        }

        public IEnumerable<DeskBooking> GetAllDbooking()
        {
            try
            {
                return deskBookingRepository.GetAllDbooking();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public DeskBooking GetDbooking(int id)
        {
            try
            {
                return deskBookingRepository.GetDbooking(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public DeskBooking BookDesk(DeskBooking db)
        {
            try
            {
                return deskBookingRepository.BookDesk(db);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public DeskBooking UpdateDbookingDetail(DeskBooking db, int id)
        {
            try
            {
                return deskBookingRepository.UpdateDbookingDetail(db, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public DeskBooking DeleteBooking(int id)
        {
            try
            {
                return deskBookingRepository.DeleteBooking(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }
    }
}
