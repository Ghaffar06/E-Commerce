using System;
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
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ValueTypeId { get; set; }

        public virtual ValueType ValueType { get; set; }
        public virtual ICollection<AttributeProductValue> AttributeProductValue { get; set; }
    }
}
