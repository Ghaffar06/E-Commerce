using AppDbContext.IRepos;
using AppDbContext.Models;

namespace AppDbContext.Repos
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        public ProductRepo(EcommerceDbContext db) : base(db)
        {

        }

    }
}
