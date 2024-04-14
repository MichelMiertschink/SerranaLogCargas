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
        public DbSet<City> City {  get; set; } = default!;
    }
}
