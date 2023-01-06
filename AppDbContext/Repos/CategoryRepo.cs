using AppDbContext.IRepos;
using AppDbContext.Models;

namespace AppDbContext.Repos
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(EcommerceDbContext db) : base(db)
        {

        }

    }
}
