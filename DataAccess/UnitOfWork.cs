using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingDbContext _shoppingDbContext;

        public UnitOfWork(ShoppingDbContext shoppingDbContext)
        {
            _shoppingDbContext = shoppingDbContext;

            Customers = new CustomerRepository(_shoppingDbContext);
            Products = new ProductRepository(_shoppingDbContext);
        }

        public ICustomerRepository Customers { get; private set; }

        public IProductRepository Products { get; private set; }

        public void Dispose()
        {
            _shoppingDbContext.Dispose();
        }

        public int Save()
        {
            return _shoppingDbContext.SaveChanges();
        }
    }
}
