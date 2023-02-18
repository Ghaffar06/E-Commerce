using ECommerceDbContext.IRepos;
using ECommerceDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerceDbContext.Repos
{
    public class ValueTypeRepo : BaseRepo<ValueType>, IValueTypeRepo
    {
        private DbSet<ValueType> ValueTypes;
        public ValueTypeRepo(EcommerceDbContext db) : base(db)
        {
            ValueTypes = _db.Set<ValueType>();
        }

        public int? Find(ValueType valueType)
        {
            var res = ValueTypes
                .Where(vt => vt.Name == valueType.Name)
                .Where(vt => vt.Type == valueType.Type)
                .FirstOrDefault();
            if (res == null)
                return null;
            else
                return res.Id;
        }
    }
}
