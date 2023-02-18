// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerceDbContext.Models
{
    public partial class CategoryAttribute
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AttributeId { get; set; }
        public string Required { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual Category Category { get; set; }
    }
}
