// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerce.Models
{
    public partial class AttributeVM
    {
        public AttributeVM()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ValueTypeId { get; set; }
        public bool Required { get; set; }

        public  ValueTypeVM ValueType { get; set; }
    }
}
