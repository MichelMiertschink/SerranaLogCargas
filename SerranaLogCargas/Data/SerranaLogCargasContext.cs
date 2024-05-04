using Microsoft.EntityFrameworkCore;
using SerranaLogCargas.Models;

namespace SerranaLogCargas.Data
{
    public class SerranaLogCargasContext : DbContext
    {
        public SerranaLogCargasContext (DbContextOptions<SerranaLogCargasContext> options)
            :base(options) 
        {
        }
        public DbSet<State> States { get; set; } = default!;
        public DbSet<City> Cities {  get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Driver> Driver { get; set; } = default!;
        public DbSet<Vehicle> Vehicles { get; set; } = default!;
        public DbSet<LoadScheduling> LoadScheduling { get; set; } = default!;
        
    }
}
