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
        public DbSet<SerranaLogCargas.Models.Driver>? Driver { get; set; } = default!;
        public DbSet<SerranaLogCargas.Models.LoadScheduling>? LoadScheduling { get; set; } = default!;
        public DbSet<SerranaLogCargas.Models.Vehicle> Vehicles { get; set; } = default!;
    }
}
