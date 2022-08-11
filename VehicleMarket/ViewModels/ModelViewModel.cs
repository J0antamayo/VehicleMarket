using VehicleMarket.Models;

namespace VehicleMarket.ViewModels
{
    public class ModelViewModel
    {
        public Model Model { get; set; }
        public Task<IEnumerable<Make>> Makes { get; set; }
    }
}
