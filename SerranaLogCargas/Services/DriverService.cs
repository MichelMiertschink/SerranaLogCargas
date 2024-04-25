using Microsoft.EntityFrameworkCore;
using SerranaLogCargas.Data;
using SerranaLogCargas.Models;

namespace SerranaLogCargas.Services
{
    public class DriverService
    {
        private readonly SerranaLogCargasContext _context;

        public DriverService (SerranaLogCargasContext context)
        {
            _context = context;
        }

        public async Task<List<Driver>> FindAllAsync()
        {
            return await _context.Driver.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
