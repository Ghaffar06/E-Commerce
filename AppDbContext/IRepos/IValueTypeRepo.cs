using ECommerceDbContext.Models;

namespace ECommerceDbContext.IRepos
{
    public interface IValueTypeRepo : IBaseRepo<ValueType>
    {
        int? Find(ValueType valueType);
    }
}
