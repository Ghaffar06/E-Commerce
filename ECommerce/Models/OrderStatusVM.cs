// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public partial class OrderStatusVM
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        [StringLength(50, ErrorMessage = "Name length can't be more than 8.")]

        public string State { get; set; }
        [StringLength(500, ErrorMessage = "Name length can't be more than 8.")]

        public string Note { get; set; }

        public virtual OrderVM Order { get; set; }
    }
}
