using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.IServices
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAllLocation();
        Location GetLocation(int id);
        Location AddLocation(Location loc);
        Location UpdateLocation(Location loc, int id);
        Location DeleteLocation(int id);
    }
}
