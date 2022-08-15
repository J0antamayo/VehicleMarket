using VehicleMarket.Models;

namespace VehicleMarket.Interfaces
{
    public interface IModelRepository
    {
        bool Add(Model model);
        bool Update(Model model);
        bool Delete(Model model);
        bool Save();
        Task<IEnumerable<Model>> GetAll();
    }
}
