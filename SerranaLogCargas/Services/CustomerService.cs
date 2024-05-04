using Microsoft.EntityFrameworkCore;
using SerranaLogCargas.Data;
using SerranaLogCargas.Models;

namespace SerranaLogCargas.Services
{
    public class CustomerService
    {
        private readonly SerranaLogCargasContext _context;
        public CustomerService(SerranaLogCargasContext context)
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
