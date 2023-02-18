using ECommerceDbContext.IRepos;
using ECommerceDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerceDbContext.Repos
{
    public class AttributeRepo : BaseRepo<Attribute>, IAttributeRepo
    {
        private DbSet<Attribute> Attributes;

        public AttributeRepo(EcommerceDbContext db) : base(db)
        {
            Attributes = _db.Set<Attribute>();
        }

        public int? Find(Attribute attribute)
        {
            var res = Attributes
                .Where(attr => attr.Name == attribute.Name)
                .Where(attr => attr.ValueTypeId == attribute.ValueTypeId)
                .FirstOrDefault();
            if (res == null)
                return null;
            else
                return res.Id;
        }

        public bool IsDeletable(int ProductId, int AttributeId)
        {
            return Attributes.Where(attr => attr.Id == AttributeId)
                .Where(attr => attr.CategoryAttribute
                    .Any(p => p.Category.CategoryProduct.Any(v => v.ProductId == ProductId))
                 )
                .Count() == 0;
        }
    }
}
