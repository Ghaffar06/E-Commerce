// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerceDbContext.Models
{
    public partial class OrderProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal Quantity { get; set; }
        public string Notes { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
