using Microsoft.EntityFrameworkCore;
using VehicleMarket.Data;
using VehicleMarket.Interfaces;
using VehicleMarket.Models;

namespace VehicleMarket.Repository
{
    public class ModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext _context;

        public ModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Model>> GetAll()
        {
            return await _context.Models.Include(m => m.Make).ToListAsync();
        }

        public async Task<Model?> GetByIdAsync(int id)
        {
            return await _context.Models.Include(m => m.Make).FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool Add(Model model)
        {
            _context.Add(model);
            return Save();
        }

        public bool Update(Model model)
        {
            _context.Update(model);
            return Save();
        }

        public bool Delete(Model model)
        {
            _context.Remove(model);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
