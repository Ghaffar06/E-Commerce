// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerce.Models
{
    public partial class CategoryAttributeViewModel
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long AttributeId { get; set; }
        public string Required { get; set; }

        public virtual AttributeViewModel Attribute { get; set; }
        public virtual CategoryViewModel Category { get; set; }
    }
}
