using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerce.Models
{
    public partial class CategoryVM
    {
        public CategoryVM()
        {
            Attributes = new HashSet<AttributeVM>();
            Products = new HashSet<ProductVM>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<AttributeVM> Attributes { get; set; }
        public virtual ICollection<ProductVM> Products { get; set; }
    }
}
