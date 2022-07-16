using Microsoft.EntityFrameworkCore;

namespace Service_Booking_Management_Microservice.Model
{
    public class AppicationContext : DbContext
    {
        public AppicationContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<AppService> AppServices { get; set; }
        public DbSet<AppServiceReport> AppServiceReports { get; set; }
    }
}
