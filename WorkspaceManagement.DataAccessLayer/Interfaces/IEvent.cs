using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.DataAccessLayer.Interfaces
{
    public interface IEvent
    {
        IEnumerable<Events> GetAllEvents();
        Events GetEvent(int id);
        Events AddEvent(Events e);
        Events UpdateEvent(Events e, int id);
        Events DeleteEvent(int id);
    }
}
