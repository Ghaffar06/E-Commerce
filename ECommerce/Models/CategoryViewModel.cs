using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class CategoryViewModel
    {
        public CategoryViewModel()
        {
            CategoryAttribute = new HashSet<CategoryAttributeViewModel>();
            CategoryProduct = new HashSet<CategoryProductViewModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<CategoryAttributeViewModel> CategoryAttribute { get; set; }
        public virtual ICollection<CategoryProductViewModel> CategoryProduct { get; set; }
    }
}
