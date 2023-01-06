using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class OrderState
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string State { get; set; }
        public string Note { get; set; }

        public virtual Order Order { get; set; }
    }
}
