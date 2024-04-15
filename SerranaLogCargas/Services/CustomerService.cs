using Microsoft.EntityFrameworkCore;
using SerranaLogCargas.Data;
using SerranaLogCargas.Models;
using System.Diagnostics.Contracts;

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
    }
}
