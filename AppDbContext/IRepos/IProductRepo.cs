using AppDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppDbContext.IRepos
{
    public interface IProductRepo : IBaseRepo<Product>
    {
        public Task<Product> GetAsync(int id);
        public List<Product> GetAllAsync(Expression<Func<Product, bool>> filter = null);
    }

}
