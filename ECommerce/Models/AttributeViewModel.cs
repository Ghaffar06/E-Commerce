using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class AttributeViewModel
    {
        public AttributeViewModel()
        {
            AttributeProductValue = new HashSet<AttributeProductValueViewModel>();
            CategoryAttribute = new HashSet<CategoryAttributeViewModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ValueTypeId { get; set; }

        public virtual ValueTypeViewModel ValueType { get; set; }
        public virtual ICollection<AttributeProductValueViewModel> AttributeProductValue { get; set; }
        public virtual ICollection<CategoryAttributeViewModel> CategoryAttribute { get; set; }
    }
}
