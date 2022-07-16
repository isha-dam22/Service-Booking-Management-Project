using Microsoft.EntityFrameworkCore;

namespace Product_Management_Microservice.Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppProduct> AppProducts { get; set; }
    }
}
