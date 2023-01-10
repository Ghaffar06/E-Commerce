using AppDbContext.IRepos;
using AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AppDbContext.Repos
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        private DbSet<Category> Categories;
        private DbSet<CategoryAttribute> CategoryAttributes;

        public CategoryRepo(EcommerceDbContext db) : base(db)
        {
            Categories = _db.Set<Category>();
            CategoryAttributes = _db.Set<CategoryAttribute>();
        }

        public Task<Category> GetAsync(int id)
        {
            return Categories
                .Where(c => c.Id == id)
                .Include(c => c.CategoryAttribute)
                .ThenInclude(c => c.Attribute)
                .ThenInclude(c => c.ValueType)
                .FirstOrDefaultAsync();
        }
      

    }
}
