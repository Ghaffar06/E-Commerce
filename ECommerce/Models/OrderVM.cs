using AppDbContext.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerce.Models
{
    public partial class OrderVM
    {
        public OrderVM()
        {
            OrderProduct = new List<OrderProductVM>();
            OrderStatus = new List<OrderStatusVM>();
        }

        public long Id { get; set; }
        public string? DelivererId { get; set; }
        public string CustomerId { get; set; }
        public double TotalPrice { get; set; }
        public string Address { get; set; }
        public decimal? Rate { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User Customer { get; set; }
        public virtual User Deliverer { get; set; }
        public virtual IList<OrderProductVM> OrderProduct { get; set; }
        public virtual IList<OrderStatusVM> OrderStatus { get; set; }
    }
}
