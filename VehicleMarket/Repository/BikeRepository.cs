using Microsoft.EntityFrameworkCore;
using VehicleMarket.Data;
using VehicleMarket.Interfaces;
using VehicleMarket.Models;

namespace VehicleMarket.Repository
{
    public class BikeRepository : IBikeRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _hostingEnvironment;


        public BikeRepository(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IEnumerable<Bike>> GetAll()
        {
            return await _context.Bikes.Include(b => b.Make).Include(b => b.Model).ToListAsync();
        }

        public async Task<Bike> GetByIdAsync(int id)
        {
            return await _context.Bikes.Include(b => b.Make).Include(b => b.Model).FirstOrDefaultAsync(b => b.Id == id);
        }

        public void UploadImage(Bike bike, IFormFileCollection files)
        {
            var BikeId = bike.Id;

            string wwrootPath = _hostingEnvironment.WebRootPath;

            var savedBike = _context.Bikes.Find(bike.Id);

            if (files.Count() != 0)
            {
                var ImagePath = @"images\bike\";
                var Extension = Path.GetExtension(files[0].FileName);
                var RelativeImagePath = ImagePath + BikeId + Extension;
                var AbsImagePath = Path.Combine(wwrootPath, RelativeImagePath);

                using (var fileStream = new FileStream(AbsImagePath, FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                savedBike.ImagePath = RelativeImagePath;

                Update(savedBike);
            }
        }

        public bool Add(Bike bike)
        {
            _context.Add(bike);
            return Save();
        }

        public bool Update(Bike bike)
        {
            _context.Update(bike);
            return Save();
        }

        public bool Delete(Bike bike)
        {
            _context.Remove(bike);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }


    }
}
