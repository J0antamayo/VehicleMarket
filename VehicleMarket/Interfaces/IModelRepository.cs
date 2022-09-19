using VehicleMarket.Models;

namespace VehicleMarket.Interfaces
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAll();
        IEnumerable<Model> GetModelList();
        Task<Model?> GetByIdAsync(int id);
        bool Add(Model model);
        bool Update(Model model);
        bool Delete(Model model);
        bool Save();
    }
}
