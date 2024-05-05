using Microsoft.EntityFrameworkCore;
using LogCargas.Data;
using LogCargas.Models;

namespace LogCargas.Services
{
    public class CustomerService
    {
        private readonly LogCargasContext _context;
        public CustomerService(LogCargasContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>> FindAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public List<Customer> FindAll()
        {
            return _context.Customers.ToList();
        }

        public async Task InsertAsync(Customer obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
