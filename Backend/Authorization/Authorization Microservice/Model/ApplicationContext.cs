using Microsoft.EntityFrameworkCore;

namespace Authorization_Microservice.Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
