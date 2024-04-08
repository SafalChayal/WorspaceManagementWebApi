using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.DataAccessLayer.Interfaces
{
    public interface ILocation
    {
        IEnumerable<Location> GetAllLocation();
        Location GetLocation(int id);
        Location AddLocation(Location loc);
        Location UpdateLocation(Location loc, int id);
        Location DeleteLocation(int id);
    }
}
