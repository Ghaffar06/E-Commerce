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
            AttributeValues = new List<AttributeValuesVM>();
            Categories = new List<CategoryVM>();
            Rate = new List<RateVM>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool PriceIsInteger { get; set; }
        public decimal Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Unit { get; set; }
        //public double Rating { get; set; }

        public virtual IList<AttributeValuesVM> AttributeValues { get; set; }
        public virtual IList<CategoryVM> Categories { get; set; }
        public virtual IList<RateVM> Rate { get; set; }
    }
}
