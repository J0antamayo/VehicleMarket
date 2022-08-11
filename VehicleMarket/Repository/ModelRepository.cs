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
