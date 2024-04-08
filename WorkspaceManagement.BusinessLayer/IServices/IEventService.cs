using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.BusinessLayer.IServices
{
    public interface IEventService
    {
        IEnumerable<Events> GetAllEvents();
        Events GetEvent(int id);
        Events AddEvent(Events e);
        Events UpdateEvent(Events e,int id);
        Events DeleteEvent(int id);
        IEnumerable<Events> GetEventsByLocation(string locationName);

    }

   
}
