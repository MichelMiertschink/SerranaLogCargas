using Microsoft.EntityFrameworkCore;
using LogCargas.Data;
using LogCargas.Models;
using LogCargas.Services.Exceptions;

namespace LogCargas.Services
{
    public class VehicleService
    {
        private readonly LogCargasContext _context;
        public VehicleService (LogCargasContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> FindAllAsync()
        {
            return await _context.Vehicles.Include(obj => obj.Driver).ToListAsync();
        }

        public async Task InsertAsync(Vehicle obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vehicle> FindByIdAsync(int Id)
        {
            return await _context.Vehicles.Include(obj => obj.Driver).FirstOrDefaultAsync(obj => obj.Id == Id);
        }

        public async Task Remove (int Id)
        {
            var obj = _context.Vehicles.Find(Id);
            _context.Vehicles.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vehicle obj)
        {
            bool hasAny = await _context.Vehicles.AnyAsync(x => x.Id == obj.Id);
            if(!hasAny)
            {
                throw new NotFoundException("Id não encontrada");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            } 
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
