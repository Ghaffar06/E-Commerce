using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerce.Models
{
    public partial class AttributeProductValueViewModel
    {
        public long Id { get; set; }
        public long AttributeId { get; set; }
        public long ProductId { get; set; }
        public string Value { get; set; }

        public virtual AttributeViewModel Attribute { get; set; }
        public virtual ProductViewModel Product { get; set; }
    }
}
