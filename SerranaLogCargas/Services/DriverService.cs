using Microsoft.EntityFrameworkCore;
using LogCargas.Data;
using LogCargas.Models;
using LogCargas.Services.Exceptions;
using System.Linq.Expressions;

namespace LogCargas.Services
{
    public class DriverService
    {
        private readonly LogCargasContext _context;

        public DriverService (LogCargasContext context)
        {
            _context = context;
        }

        public async Task<List<Driver>> FindAllAsync()
        {
            return await _context.Driver.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Driver obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Driver> FindByIdAsync(int id)
        {
            return await _context.Driver.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task UpdateAsync (Driver driver)
        {
            bool hasAny = await _context.Driver.AnyAsync(x => x.Id == driver.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrada");
            }
            
            try
            {
                _context.Update(driver);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task Remove (int id)
        {
            var driver = _context.Driver.Find(id);
            _context.Driver.Remove(driver);
            await _context.SaveChangesAsync();
        }
    }
}
