using ECommerceDbContext.Models;

namespace ECommerceDbContext.IRepos
{
    public interface IAttributeRepo : IBaseRepo<Attribute>
    {
        int? Find(Attribute attribute);
        bool IsDeletable(int ProductId, int AttributeId);
    }
}
