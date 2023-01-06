// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class OrderProduct
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public decimal Quantity { get; set; }
        public string Notes { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
