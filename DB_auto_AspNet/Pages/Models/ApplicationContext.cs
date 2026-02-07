using Microsoft.EntityFrameworkCore;

namespace DB_auto_AspNet.Pages.Models
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VehicleDb;Username=postgres;Password=Passw0rd");
        //}
    }
}
