using VehicleMarket.Models;

namespace VehicleMarket.Interfaces
{
    public interface ICurrecyRepository
    {
        IEnumerable<Currency> GetCurrencyList();
    }
}
