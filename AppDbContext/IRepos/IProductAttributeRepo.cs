using AppDbContext.Models;

namespace AppDbContext.IRepos
{
    public interface IProductAttributeRepo : IBaseRepo<AttributeProductValue>
    {
        int? Find(AttributeProductValue valueType);

    }
}
