using Microsoft.EntityFrameworkCore;
using WorkspaceManagement.DataAccessLayer.Data;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;
namespace WorkSpaceManagemetApi.Repository
{
    public class EventRepository:IEvent
    {
        private readonly WorkSpaceDbContext _dbContext;

        public EventRepository(WorkSpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Events> GetAllEvents()
        {
            try
            {
                return _dbContext.Events.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Events GetEvent(int id)
        {
            try
            {
                var eventt = _dbContext.Events.Include(x=>x.Location).FirstOrDefault(x=>x.EventId==id);
                if (eventt == null)
                {
                    throw new Exception();
                }
                return eventt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Events AddEvent(Events e)
        {
            try
            {
                _dbContext.Events.Add(e);
                _dbContext.SaveChanges();
                return e;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Events UpdateEvent(Events e, int id)
        {
            try
            {
                var existingEvent = _dbContext.Events.Find(id);
                if (existingEvent == null)
                {
                    throw new Exception();
                }
                existingEvent.EventTitle = e.EventTitle;
                _dbContext.SaveChanges();
                return existingEvent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Events DeleteEvent(int id)
        {
            try
            {
                var eventToDelete = _dbContext.Events.Find(id);
                if (eventToDelete == null)
                {
                    throw new Exception();
                }
                _dbContext.Events.Remove(eventToDelete);
                _dbContext.SaveChanges();
                return eventToDelete;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
