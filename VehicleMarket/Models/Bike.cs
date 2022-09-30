using System.ComponentModel.DataAnnotations;
using VehicleMarket.Common;

namespace VehicleMarket.Models
{
    public class Bike
    {
        public int Id { get; set; }

        public Make Make { get; set; }

        [Required(ErrorMessage = "Select Make")]
        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Make")]
        public int MakeId { get; set; }

        public Model Model { get; set; }

        [Required(ErrorMessage = "Select Model")]
        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Make")]
        public int ModelId { get; set; }

        [Required(ErrorMessage = "Provide Year")]
        [YearRangeTillDate(2000, ErrorMessage = "Invalid Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Provide Mileage")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Mileage")]
        public int Mileage { get; set; }

        public string? Features { get; set; }

        [Required(ErrorMessage = "Provide Seller Name")]
        public string? SellerName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? SellerEmail { get; set; }

        [Required(ErrorMessage = "Provide Seller Phone")]
        public string? SellerPhone { get; set; }

        public string? ImagePath { get; set; }

        public int Price { get; set; }

        public Currency Currency { get; set; }

        [Required(ErrorMessage = "Select Currency")]
        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Make")]
        public int CurrencyId { get; set; }
    }
}
