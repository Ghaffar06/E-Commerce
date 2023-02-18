using AppDbContext.Models;

namespace AppDbContext.IRepos
{
    public interface ICategoryProductRepo : IBaseRepo<CategoryProduct>
    {
        int? Find(CategoryProduct categoryProduct);
    }
}
