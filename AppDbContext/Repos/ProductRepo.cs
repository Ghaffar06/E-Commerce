using AppDbContext.IRepos;
using AppDbContext.Models;

namespace AppDbContext.Repos
{
    public class ProductRepo : BaseRepo<Category>, IProductRepo
    {
        public ProductRepo(EcommerceDbContext db) : base(db)
        {

        }

    }
}
