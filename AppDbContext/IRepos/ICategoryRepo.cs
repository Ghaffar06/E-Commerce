using ECommerceDbContext.Models;
using System.Threading.Tasks;

namespace ECommerceDbContext.IRepos
{
    public interface ICategoryRepo : IBaseRepo<Category>
    {
        Task<Category> GetAsync(int id);

      
    }
}
