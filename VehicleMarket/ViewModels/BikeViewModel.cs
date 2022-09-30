using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using VehicleMarket.Models;

namespace VehicleMarket.ViewModels
{
    public class BikeViewModel
    {
        [ValidateNever]
        public Bike Bike { get; set; }
        [ValidateNever]
        public IEnumerable<Make> Makes { get; set; }
        [ValidateNever]
        public IEnumerable<Model> Models { get; set; }
        [ValidateNever]
        public IEnumerable<Currency> Currencies { get; set; }

    }
}
