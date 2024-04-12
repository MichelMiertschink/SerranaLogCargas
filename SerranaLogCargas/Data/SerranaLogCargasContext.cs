using Microsoft.EntityFrameworkCore;

namespace SerranaLogCargas.Data
{
    public class SerranaLogCargasContext : DbContext
    {
        public SerranaLogCargasContext (DbContextOptions<SerranaLogCargasContext> options)
            :base(options) { }
    }
}
