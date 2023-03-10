using AppDbContext.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDbContext.IRepos
{
    public interface IOrderRepo : IBaseRepo<Order>
    {
        Task<List<Order>> GetAccepted(string userId);
        Task<Order> GetAsync(int id);
        Task<List<Order>> GetRequested(string userId);
        Task<List<Order>> GetWaiting();

    }
}
