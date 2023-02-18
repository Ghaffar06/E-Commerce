using ECommerceDbContext.Models;

namespace ECommerceDbContext.IRepos
{
    public interface IProductAttributeRepo : IBaseRepo<AttributeProductValue>
    {
        int? Find(AttributeProductValue valueType);

    }
}
