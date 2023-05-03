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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ShoppingDbContext dbContext) : base(dbContext)
        {            
        }

        //Products More than 100 dollars are being considered expensive
        public async Task<IEnumerable<Product>> GetExpensiveProducts()
        {
            var products = await _shoppingDbContext.Products.Where(x => x.Price > 100.0m).ToListAsync();
            return products;
        }
    }
}
