using Microsoft.EntityFrameworkCore;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkspaceManagement.DataAccessLayer.Data
{
    public class WorkSpaceDbContext:DbContext
    {
       
        public DbSet<DeskBooking> DeskBookings { get; set; } 
        public DbSet<RoomDetail> RoomDetail { get; set; }
        public DbSet<RoomBooking> RoomBooking { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<AdminRegister> AdminRegisters { get; set; }
        public WorkSpaceDbContext(DbContextOptions<WorkSpaceDbContext> options) : base(options)
        {

        }
    }
}
