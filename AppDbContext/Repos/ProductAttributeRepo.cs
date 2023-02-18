using ECommerceDbContext.IRepos;
using ECommerceDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerceDbContext.Repos
{
    public class ProductAttributeRepo : BaseRepo<AttributeProductValue>, IProductAttributeRepo
    {
        private DbSet<AttributeProductValue> AttributeProductValues;

        public ProductAttributeRepo(EcommerceDbContext db) : base(db)
        {
            AttributeProductValues = _db.Set<AttributeProductValue>();
        }

        public int? Find(AttributeProductValue attributeProductValue)
        {
            var res = AttributeProductValues
                .Where(pa => pa.ProductId == attributeProductValue.ProductId)
                .Where(pa => pa.AttributeId == attributeProductValue.AttributeId)
                .FirstOrDefault();
            if (res == null)
                return null;
            else
                return res.Id;
        }
        public override void Add(AttributeProductValue item)
        {
            if (Find(item) == null)
                base.Add(item);
        }

    }
}
