using Microsoft.EntityFrameworkCore;
using LogCargas.Data;
using LogCargas.Models;
using LogCargas.Services.Exceptions;

namespace LogCargas.Services
{
    public class StateService
    {
        private readonly LogCargasContext _context;
        public StateService(LogCargasContext context)
        {
            _context = context;
        }

        public async Task<List<State>> FindAllAsync()
        {
            return await _context.States.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(State state)
        {
            _context.Add(state);
            await _context.SaveChangesAsync();
        }

        public async Task<State> FindByIdAsync (int id)
        {
            return await _context.States.FirstOrDefaultAsync(state => state.Id == id);
        }

        public async Task Remove (int id)
        {
            try
            {
                var state = _context.States.Find(id);
                _context.States.Remove(state);
                await _context.SaveChangesAsync();
            }catch (IntegrityException e)
            {
                throw new DbConcurrencyException ("Não é possível excluir, pois o Estado possui cidade cadastrada") ;
            }
        }

        public async Task UpdateAsync(State state)
        {
            bool hasAny = await _context.States.AnyAsync(x => x.Id == state.Id);
            if (!hasAny){
                throw new NotFoundException("Id não encontrada");
            }

            try
            {
                _context.Update(state);
                await _context.SaveChangesAsync();
            }catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
