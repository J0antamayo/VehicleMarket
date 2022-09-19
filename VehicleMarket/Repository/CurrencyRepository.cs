using VehicleMarket.Data;
using VehicleMarket.Interfaces;
using VehicleMarket.Models;

namespace VehicleMarket.Repository
{
    public class CurrencyRepository : ICurrecyRepository
    {
        private readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Currency> GetCurrencyList()
        {
            return _context.Currencies.ToList();
        }
    }
}
