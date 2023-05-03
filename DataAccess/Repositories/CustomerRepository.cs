using BusinessDomain.Entities;
using DataAccess.Interfaces;
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

        public IEnumerable<Customer> GetCustomersFromZipCode(string zipcode)
        {
            var customers =_shoppingDbContext.Customers.Where(x => x.Zipcode == zipcode );

           return customers;
        }
    }
}
