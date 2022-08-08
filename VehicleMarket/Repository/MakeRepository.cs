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

        public async Task<Make?> GetByIdAsync(int id)
        {
            return await _context.Makes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Add(Make make)
        {
            _context.Makes.Add(make);
            return Save();
        }

        public bool Update(Make make)
        {
            _context.Makes.Update(make);
            return Save();
        }

        public bool Delete(Make make)
        {
            _context.Makes.Remove(make);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

    }
}
