using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ShoppingDbContext _shoppingDbContext;
        public GenericRepository(ShoppingDbContext context)
        {
            _shoppingDbContext = context;
        }

        public void Add(T entity)
        {
            _shoppingDbContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _shoppingDbContext.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _shoppingDbContext.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _shoppingDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _shoppingDbContext.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _shoppingDbContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _shoppingDbContext.Set<T>().RemoveRange(entities);
        }
    }
}
