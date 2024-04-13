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

        public State FindById(int id) 
        {
            return _context.States.FirstOrDefault(obj => obj.Id == id);
        }

        public void Insert(State obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(State obj) { }

        public void Remove(int id)
        {
            var obj = _context.States.Find(id);
            _context.States.Remove(obj);
            _context.SaveChanges();
        }
    }
}
