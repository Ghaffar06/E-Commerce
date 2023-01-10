using AppDbContext.IRepos;
using AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AppDbContext.Repos
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

    }
}
