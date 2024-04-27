using Microsoft.EntityFrameworkCore;
using SerranaLogCargas.Data;
using SerranaLogCargas.Models;

namespace SerranaLogCargas.Services
{
    public class LoadSchedulingService
    {
        private readonly SerranaLogCargasContext _context;
        public LoadSchedulingService (SerranaLogCargasContext context)
        {
            _context = context;
        }

        public async Task<List<LoadScheduling>> FindAllAsync()
        {
            return await _context.LoadScheduling
                .Include(cityDestiny => cityDestiny.CityDestiny)
                .Include(cityOrigin => cityOrigin.CityOrigin)
                .Include(customerId => customerId.Customer)
                .ToListAsync();
        }

        public async Task InsertAsync(LoadScheduling loadScheduling)
        {
            _context.Add(loadScheduling);
            await _context.SaveChangesAsync();
        }

        public async Task<LoadScheduling> FindByIdAsync(int id)
        {
            return await _context.LoadScheduling
                .Include(cityDestiny => cityDestiny.CityDestiny)
                .Include(cityOrigin => cityOrigin.CityOrigin)
                .Include(customerId => customerId.Customer)
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }
    }
}
