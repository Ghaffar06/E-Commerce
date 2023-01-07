using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class ValueTypeViewModel
    {
        public ValueTypeViewModel()
        {
            Attribute = new HashSet<AttributeViewModel>();
        }

        public long Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AttributeViewModel> Attribute { get; set; }
    }
}
