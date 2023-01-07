using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerce.Models
{
    public partial class ProductVM
    {
        public ProductVM()
        {
            AttributeValues = new HashSet<AttributeValuesVM>();
            Categories = new HashSet<CategoryVM>();
            Rate = new HashSet<RateVM>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PriceIsInteger { get; set; }
        public decimal Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Unit { get; set; }
        //public double Rating { get; set; }

        public virtual ICollection<AttributeValuesVM> AttributeValues { get; set; }
        public virtual ICollection<CategoryVM> Categories { get; set; }
        public virtual ICollection<RateVM> Rate { get; set; }
    }
}
