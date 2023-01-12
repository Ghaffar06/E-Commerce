using AppDbContext.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDbContext.IRepos
{
    public interface IProductRepo : IBaseRepo<Product>
    {
        public Task<Product> GetAsync(int id);
        public List<Product> GetAllAsync();
    }

}
