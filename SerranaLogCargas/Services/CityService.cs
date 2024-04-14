using Microsoft.EntityFrameworkCore;
using SerranaLogCargas.Data;
using SerranaLogCargas.Models;


namespace SerranaLogCargas.Services
{
    public class CityService
    {
        private readonly SerranaLogCargasContext _context;
        public CityService(SerranaLogCargasContext context)
        {
            _context = context;
        }   

        public async Task<List<City>> FindAllAsync()
        {
            return await _context.City.ToListAsync();
        }

        public async Task InsertAsync(City obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        
    
    }
}
