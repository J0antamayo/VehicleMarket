using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using VehicleMarket.Models;

namespace VehicleMarket.ViewModels
{
    public class ModelViewModel
    {
        [ValidateNever]
        public Model Model { get; set; }
        [ValidateNever]
        public IEnumerable<Make> Makes { get; set; }
    }
}
