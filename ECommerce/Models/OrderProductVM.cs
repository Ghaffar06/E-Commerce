// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerce.Models
{
    public partial class OrderProductVM
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public decimal Quantity { get; set; }
        public string Notes { get; set; }

        public virtual OrderVM Order { get; set; }
        public virtual ProductVM Product { get; set; }
    }
}
