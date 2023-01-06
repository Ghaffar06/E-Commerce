using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerce.Models
{
    public partial class ProductViewModel
    {
        public ProductViewModel()
        {
            AttributeProductValue = new HashSet<AttributeProductValueViewModel>();
            CategoryProduct = new HashSet<CategoryProductViewModel>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PriceIsInteger { get; set; }
        public decimal Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<AttributeProductValueViewModel> AttributeProductValue { get; set; }
        public virtual ICollection<CategoryProductViewModel> CategoryProduct { get; set; }
    }
}
