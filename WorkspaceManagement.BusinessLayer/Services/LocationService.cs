using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.DataAccessLayer.CustomException;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.Services
{
    public class LocationService:ILocationService
    {
        private readonly ILocation locationRepository;

        public LocationService(ILocation locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public IEnumerable<Location> GetAllLocation()
        {
            try
            {
                return locationRepository.GetAllLocation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Location GetLocation(int id)
        {
            try
            {
                return locationRepository.GetLocation(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Location AddLocation(Location loc)
        {
            try
            {
                return locationRepository.AddLocation(loc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Location UpdateLocation(Location loc, int id)
        {
            try
            {
                return locationRepository.UpdateLocation(loc, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

        public Location DeleteLocation(int id)
        {
            try
            {
                return locationRepository.DeleteLocation(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new CustomDataAccessException("Error Occurred", ex);
            }
        }

    }
}
