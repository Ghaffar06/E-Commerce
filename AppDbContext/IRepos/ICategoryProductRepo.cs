using ECommerceDbContext.Models;

namespace ECommerceDbContext.IRepos
{
    public interface ICategoryProductRepo : IBaseRepo<CategoryProduct>
    {
        int? Find(CategoryProduct categoryProduct);
    }
}
