using AppDbContext.IRepos;
using AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
