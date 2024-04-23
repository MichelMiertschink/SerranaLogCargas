using Microsoft.EntityFrameworkCore;
using SerranaLogCargas.Data;
using SerranaLogCargas.Models;

namespace SerranaLogCargas.Services
{
    public class StateService
    {
        private readonly SerranaLogCargasContext _context;
        public StateService(SerranaLogCargasContext context)
        {
            _context = context;
        }

        public async Task<List<State>> FindAllAsync()
        {
            return await _context.States.OrderBy(x => x.Name).ToListAsync();
        }
       
    }
}
