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

        public async Task<City> FindByIdAsync(int id)
        {
            return await _context.City.Include(obj => obj.State).FirstOrDefaultAsync(obj => obj.Id == id);
        }


        public async Task Remove(int id)
        {
            var obj = _context.City.Find(id);
            _context.City.Remove(obj);
            await _context.SaveChangesAsync();
        }
        
    
    }
}
