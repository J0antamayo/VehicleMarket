using VehicleMarket.Models;

namespace VehicleMarket.Interfaces
{
    public interface IMakeRepository
    {
        Task<IEnumerable<Make>> GetAll();
    }
}
