using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        [StringLength(500,ErrorMessage = "Name length can't be more than 8.")]
        public string Description { get; set; }

        [Range(0.01, 10000.00,
            ErrorMessage = "Price must be between 0.01 and 10000.00")]
        public double Price { get; set; }
        [DisplayName("Price is integer")]
        public bool PriceIsInteger { get; set; }
        [Range(0.01, 100.00,
            ErrorMessage = "Quantity must be between 0.01 and 100.00")]
        public decimal Quantity { get; set; }

        [DisplayName("Album Art URL")]
        public string ImageUrl { get; set; }
        [StringLength(30)]
        public string Unit { get; set; }
        //public double Rating { get; set; }


        public virtual IList<AttributeValuesVM> AttributeValues { get; set; }
        public virtual IList<CategoryVM> Categories { get; set; }
        public virtual IList<RateVM> Rate { get; set; }
    }
}
