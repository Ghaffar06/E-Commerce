using AppDbContext.IRepos;
using AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppDbContext.Repos
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        private DbSet<Product> Products;

        public ProductRepo(EcommerceDbContext db) : base(db)
        {
            Products = _db.Set<Product>();
        }

        public List<Product> GetAllAsync(Expression<Func<Product, bool>> filter = null)
        {
            IQueryable<Product> query = Products;

            if (filter != null)
                query = query.Where(filter);
            query = query
                .Include(c => c.CategoryProduct)
                .ThenInclude(c => c.Category)
                .ThenInclude(c => c.CategoryAttribute)
                .Include(c => c.AttributeProductValue)
                .ThenInclude(c => c.Attribute)
                .ThenInclude(c => c.ValueType);
            
            return query.ToList();
        }

        public Task<Product> GetAsync(int id)
        {
            return Products
                .Where(c => c.Id == id)
                .Include(c => c.CategoryProduct)
                .ThenInclude(c => c.Category)
                .Include(c => c.AttributeProductValue)
                .ThenInclude(c => c.Attribute)
                .ThenInclude(c => c.ValueType)
                .FirstOrDefaultAsync();
        }
    }
}
