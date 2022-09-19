using System.ComponentModel.DataAnnotations;

namespace VehicleMarket.Models
{
    public class Bike
    {
        public int Id { get; set; }

        public Make Make { get; set; }

        public int MakeId { get; set; }

        public Model Model { get; set; }

        public int ModelId { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Mileage { get; set; }

        public string? Features { get; set; }

        [Required]
        public string? SellerName { get; set; }

        public string? SellerEmail { get; set; }

        [Required]
        public string? SellerPhone { get; set; }

        public string? ImagePath { get; set; }

        public int Price { get; set; }

        [Required]
        public Currency Currency { get; set; }

        public int CurrencyId { get; set; }
    }
}
