using VehicleMarket.Models;

namespace VehicleMarket.Interfaces
{
    public interface IMakeRepository
    {
        Task<IEnumerable<Make>> GetAll();
        Task<Make?> GetByIdAsync(int id);
        bool Add(Make make);
        bool Update(Make make);
        bool Delete(Make make);
        bool Save();
    }
}
