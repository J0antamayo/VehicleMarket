using VehicleMarket.Models;

namespace VehicleMarket.Interfaces
{
    public interface IBikeRepository
    {
        Task<IEnumerable<Bike>> GetAll();
        Task<Bike> GetByIdAsync(int id);
        void UploadImage(Bike bike, IFormFileCollection files);
        bool Add(Bike bike);
        bool Update(Bike bike);
        bool Delete(Bike bike);
        bool Save();
    }
}
