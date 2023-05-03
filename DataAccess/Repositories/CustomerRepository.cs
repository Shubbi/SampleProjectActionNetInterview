using BusinessDomain.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShoppingDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<IEnumerable<Customer>> GetCustomersFromZipCode(string zipcode)
        {
            var customers =await _shoppingDbContext.Customers.Where(x => x.Zipcode == zipcode ).ToListAsync();

           return customers;
        }
    }
}
