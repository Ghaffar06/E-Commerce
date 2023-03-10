// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public partial class AttributeVM
    {
        public AttributeVM()
        {
        }

        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Name length can't be more than 8.")]

        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Name length can't be more than 8.")]

        public string Description { get; set; }
        public long ValueTypeId { get; set; }
        public bool Required { get; set; }

        public  ValueTypeVM ValueType { get; set; }
    }
}
