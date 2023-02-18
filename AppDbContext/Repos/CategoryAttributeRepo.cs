using ECommerceDbContext.IRepos;
using ECommerceDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerceDbContext.Repos
{
    public class CategoryAttributeRepo : BaseRepo<CategoryAttribute>, ICategoryAttributeRepo
    {
        private DbSet<CategoryAttribute> CategoryAttributes;

        public CategoryAttributeRepo(EcommerceDbContext db) : base(db)
        {
            CategoryAttributes = _db.Set<CategoryAttribute>();
        }

    }
}
