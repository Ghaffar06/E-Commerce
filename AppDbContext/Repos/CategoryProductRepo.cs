using AppDbContext.IRepos;
using AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AppDbContext.Repos
{
    public class CategoryProductRepo : BaseRepo<CategoryProduct>, ICategoryProductRepo
    {
        private DbSet<CategoryProduct> CategoryProducts;

        public CategoryProductRepo(EcommerceDbContext db) : base(db)
        {
            CategoryProducts = _db.Set<CategoryProduct>();
        }

      
    }
}
