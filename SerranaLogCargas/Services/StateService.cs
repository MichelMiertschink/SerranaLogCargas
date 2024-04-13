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
        
        public List<State> FindAll() 
        {
            return _context.States.ToList();
        }

        public void Insert(State obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
