using ECommerceDbContext.IRepos;
using ECommerceDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerceDbContext.Repos
{
    public class CategoryProductRepo : BaseRepo<CategoryProduct>, ICategoryProductRepo
    {
        private DbSet<CategoryProduct> CategoryProducts;

        public CategoryProductRepo(EcommerceDbContext db) : base(db)
        {
            CategoryProducts = _db.Set<CategoryProduct>();
        }

        public int? Find(CategoryProduct categoryProduct)
        {
            var res = CategoryProducts
                .Where(c => c.CategoryId == categoryProduct.CategoryId)
                .Where(c => c.ProductId == categoryProduct.ProductId)
                .FirstOrDefault();
            if (res == null)
                return null;
            else
                return (int)res.Id;
        }
    }
}
