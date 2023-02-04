using AppDbContext.Models;
using System.Threading.Tasks;

namespace AppDbContext.IRepos
{
    public interface IOrderRepo : IBaseRepo<Order>
    {
        Task<Order> GetAsync(int id);

      
    }
}
