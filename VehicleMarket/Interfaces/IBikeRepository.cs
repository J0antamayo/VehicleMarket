using cloudscribe.Pagination.Models;
using VehicleMarket.Models;

namespace VehicleMarket.Interfaces
{
    public interface IBikeRepository
    {
        PagedResult<Bike> GetBikes(int PageSize, int PageNumber, string SortOrder, string SearchString);
        Task<Bike> GetByIdAsync(int id);
        void UploadImage(Bike bike, IFormFileCollection files);
        bool Add(Bike bike);
        bool Update(Bike bike);
        bool Delete(Bike bike);
        bool Save();
    }
}
