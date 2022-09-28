using VehicleMarket.Models;

namespace VehicleMarket.Interfaces
{
    public interface IBikeRepository
    {
        IEnumerable<Bike> GetAll(int ExcludeRecords, int PageSize);
        Task<Bike> GetByIdAsync(int id);
        void UploadImage(Bike bike, IFormFileCollection files);
        bool Add(Bike bike);
        bool Update(Bike bike);
        bool Delete(Bike bike);
        bool Save();
    }
}
