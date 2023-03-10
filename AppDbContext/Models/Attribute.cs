using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class Attribute
    {
        public Attribute()
        {
            AttributeProductValue = new HashSet<AttributeProductValue>();
            CategoryAttribute = new HashSet<CategoryAttribute>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ValueTypeId { get; set; }

        public virtual ValueType ValueType { get; set; }
        public virtual ICollection<AttributeProductValue> AttributeProductValue { get; set; }
        public virtual ICollection<CategoryAttribute> CategoryAttribute { get; set; }
    }
}
