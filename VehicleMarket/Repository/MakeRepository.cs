using Microsoft.EntityFrameworkCore;
using VehicleMarket.Data;
using VehicleMarket.Interfaces;
using VehicleMarket.Models;

namespace VehicleMarket.Repository
{
    public class MakeRepository : IMakeRepository
    {
        public readonly ApplicationDbContext _context;
        public MakeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Make>> GetAll()
        {
            return await _context.Makes.ToListAsync();
        }

    }
}
