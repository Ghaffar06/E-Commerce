// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public partial class ValueTypeVM
    {
        public ValueTypeVM()
        {
        }

        public long Id { get; set; }
        [StringLength(50, ErrorMessage = "Name length can't be more than 8.")]

        public string Type { get; set; }
        [StringLength(50, ErrorMessage = "Name length can't be more than 8.")]

        public string Name { get; set; }

    }
    public enum ValueTypeEnum
    {
        Int,
        Float,
        String,
    }
}
