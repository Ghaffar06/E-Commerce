using AppDbContext.Models;
using System.Threading.Tasks;

namespace AppDbContext.IRepos
{
    public interface ICategoryRepo : IBaseRepo<Category>
    {
        Task<Category> GetAsync(int id);

        void AssignAttribute(CategoryAttribute categoryAttribute);
        void ClearAssignmentAttribute(int categoryAttributeId);
    }
}
