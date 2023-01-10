using AppDbContext.IRepos;
using AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AppDbContext.Repos
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
