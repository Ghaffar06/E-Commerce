using ECommerceDbContext.Models;
using System.Threading.Tasks;

namespace ECommerceDbContext.IRepos
{
    public interface IOrderRepo : IBaseRepo<Order>
    {
        Task<Order> GetAsync(int id);

      
    }
}
