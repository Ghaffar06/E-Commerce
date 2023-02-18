using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class Product
    {
        public Product()
        {
            AttributeProductValue = new HashSet<AttributeProductValue>();
            CategoryProduct = new HashSet<CategoryProduct>();
            OrderProduct = new HashSet<OrderProduct>();
            Rate = new HashSet<Rate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PriceIsInteger { get; set; }
        public decimal Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<AttributeProductValue> AttributeProductValue { get; set; }
        public virtual ICollection<CategoryProduct> CategoryProduct { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public virtual ICollection<Rate> Rate { get; set; }
    }
}
