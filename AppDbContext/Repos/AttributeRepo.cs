using AppDbContext.IRepos;
using AppDbContext.Models;

namespace AppDbContext.Repos
{
    public class AttributeRepo : BaseRepo<Attribute>, IAttributeRepo
    {
        public AttributeRepo(EcommerceDbContext db) : base(db)
        {

        }

    }
}
