using Microsoft.EntityFrameworkCore;
using SerranaLogCargas.Data;
using SerranaLogCargas.Models;
using SerranaLogCargas.Services.Exceptions;

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
                .Include(obj => obj.CityOrigin)
                .Include(obj => obj.CityDestiny)
                .Include(obj => obj.Customer)
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }


        public async Task RemoveAsync(int id)
        {
            var loadScheduling = _context.LoadScheduling.Find(id);
            _context.LoadScheduling.Remove(loadScheduling);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync (LoadScheduling loadScheduling)
        {
            bool hasAny = await _context.LoadScheduling.AnyAsync(x => x.Id == loadScheduling.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrada");
            }

            try
            {
                _context.Update(loadScheduling);
                await _context.SaveChangesAsync();
            } catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
