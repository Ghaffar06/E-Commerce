using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerceDbContext.Models
{
    public partial class ValueType
    {
        public ValueType()
        {
            Attribute = new HashSet<Attribute>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Attribute> Attribute { get; set; }
    }
}
