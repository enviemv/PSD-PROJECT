using System;
using System.ComponentModel.DataAnnotations;

namespace GymMe.Models
{
    public class SupplementViewModel
    {
        public int SupplementID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(".*Supplement.*", ErrorMessage = "Name must contain 'Supplement'")]
        public required string SupplementName { get; set; }

        [Required(ErrorMessage = "Expiry Date is required")]
        [DataType(DataType.Date)]
        [DateGreaterThanToday(ErrorMessage = "Expiry Date must be greater than today's date")]
        public DateTime SupplementExpiryDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(3000, double.MaxValue, ErrorMessage = "Price must be at least 3000")]
        public decimal SupplementPrice { get; set; }

        [Required(ErrorMessage = "Type ID is required")]
        public required string SupplementTypeName { get; set; }
    }

    public class DateGreaterThanTodayAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (DateTime)value > DateTime.Now;
        }
    }
}
