using Microsoft.EntityFrameworkCore;
using SerranaLogCargas.Data;
using SerranaLogCargas.Models;

namespace SerranaLogCargas.Services
{
    public class VehicleService
    {
        private readonly SerranaLogCargasContext _context;
        public VehicleService (SerranaLogCargasContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> FindAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

    }
}
