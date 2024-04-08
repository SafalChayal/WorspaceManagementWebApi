using WorkspaceManagement.DataAccessLayer.Data;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public class LocationRepository:ILocation
    {
        private readonly WorkSpaceDbContext _dbContext;

        public LocationRepository(WorkSpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Location> GetAllLocation()
        {
            try
            {
                return _dbContext.Location.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Location GetLocation(int id)
        {
            try
            {
                var location= _dbContext.Location.Find(id);
                if (location == null)
                {
                    throw new Exception();
                }
                return location;    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Location AddLocation(Location loc)
        {
            try
            {
                _dbContext.Location.Add(loc);
                _dbContext.SaveChanges();
                return loc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Location UpdateLocation(Location loc, int id)
        {
            try
            {
                var existingLocation = _dbContext.Location.Find(id);
                if (existingLocation == null)
                {
                    throw new Exception();
                }
                existingLocation.FloorNumberOrBuildingName = loc.FloorNumberOrBuildingName;
                _dbContext.SaveChanges();
                return existingLocation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Location DeleteLocation(int id)
        {
            try
            {
                var locationToDelete = _dbContext.Location.Find(id);
                if (locationToDelete == null)
                {
                    throw new Exception();   
                }
                _dbContext.Location.Remove(locationToDelete);
                _dbContext.SaveChanges();
                return locationToDelete;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
