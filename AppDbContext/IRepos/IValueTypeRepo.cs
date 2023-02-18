using AppDbContext.Models;

namespace AppDbContext.IRepos
{
    public interface IValueTypeRepo : IBaseRepo<ValueType>
    {
        int? Find(ValueType valueType);
    }
}
