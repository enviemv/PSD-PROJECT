using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymMe.Models
{
    public class OrderSupplementViewModel
    {
        public int SupplementID { get; set; }
        public required string SupplementName { get; set; }
        public DateTime SupplementExpiryDate { get; set; }
        public decimal SupplementPrice { get; set; }
        public required string SupplementTypeName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
    }

    public class OrderSupplementListViewModel
    {
        public List<OrderSupplementViewModel> Supplements { get; set; } = new List<OrderSupplementViewModel>();
        public string CartAction { get; set; } = string.Empty;
    }
}
