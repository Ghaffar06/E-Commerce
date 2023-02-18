using ECommerceDbContext.IRepos;
using ECommerceDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceDbContext.Repos
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        private DbSet<Order> Orders;

        public OrderRepo(EcommerceDbContext db) : base(db)
        {
            Orders = _db.Set<Order>();
        }

        public Task<Order> GetAsync(int id)
        {
            return Orders
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }
      

    }
}
