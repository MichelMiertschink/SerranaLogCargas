using Microsoft.EntityFrameworkCore;
using LogCargas.Models;

namespace LogCargas.Data
{
    public class LogCargasContext : DbContext
    {
        public LogCargasContext (DbContextOptions<LogCargasContext> options)
            :base(options) 
        {
        }
        public DbSet<State> States { get; set; } = default!;
        public DbSet<City> Cities {  get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Driver> Driver { get; set; } = default!;
        public DbSet<Vehicle> Vehicles { get; set; } = default!;
        public DbSet<LoadScheduling> LoadScheduling { get; set; } = default!;
        
        // public DbSet<IdentityUser> IdentityUser { get; set; } = default!;
    }
}
