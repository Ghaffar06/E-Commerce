using AppDbContext.IRepos;
using AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDbContext.Repos
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        private DbSet<Order> Orders;

        public OrderRepo(EcommerceDbContext db) : base(db)
        {
            Orders = _db.Set<Order>();
        }

        public Task<List<Order>> GetAccepted(string userId)
        {
            return Orders
                .Where(c => c.DelivererId == userId)
                .Include(c => c.OrderStatus)
                .ToListAsync();
        }

        public Task<Order> GetAsync(int id)
        {
            return Orders
                .Where(c => c.Id == id)
                .Include(c => c.OrderStatus)
                .Include(c => c.OrderProduct)
                .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync();
        }

        public Task<List<Order>> GetRequested(string userId)
        {
            return Orders
                .Where(c => c.CustomerId == userId)
                .Include(c => c.OrderStatus)
                .ToListAsync();
        }

        public Task<List<Order>> GetWaiting()
        {
            return Orders
                .Where(c => c.DelivererId == null)
                .Include(c => c.OrderStatus)
                .ToListAsync();
        }



    }
}
