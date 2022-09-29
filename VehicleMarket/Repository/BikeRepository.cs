using cloudscribe.Pagination.Models;
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

        public PagedResult<Bike> GetBikes(int PageSize, int PageNumber, string SortOrder, string SearchString)
        {
            int excludeRecords = this.getExcludeRecords(PageSize, PageNumber);

            IQueryable<Bike> bikes = this.getBikesQuery();

            bikes = this.searchBikesByMake(bikes, SearchString);

            var bikesCount = bikes.Count();

            bikes = this.SortByPrice(bikes, SortOrder);

            var data = bikes
                    .Skip(excludeRecords)
                    .Take(PageSize)
                    .AsNoTracking()
                    .ToList();

            return new PagedResult<Bike>
            {
                Data = data,
                TotalItems = bikesCount,
                PageNumber = PageNumber,
                PageSize = PageSize,
            };
        }

        public IQueryable<Bike> getBikesQuery()
        {
            return from b in _context.Bikes.Include(b => b.Make).Include(b => b.Model)
                   select b;
        }

        public int getExcludeRecords(int PageSize, int PageNumber)
        {
            int ExcludeRecords = (PageSize * PageNumber) - PageSize;
            return ExcludeRecords;
        }

        public IQueryable<Bike> searchBikesByMake(IQueryable<Bike> Bikes, string SearchFilter)
        {
            var result = Bikes;
            if (!String.IsNullOrEmpty(SearchFilter))
            {
                result = result.Where(b => b.Make.Name.Contains(SearchFilter));
            }
            return result;
        }

        public IQueryable<Bike> SortByPrice(IQueryable<Bike> Bikes, string SortOrder)
        {
            var result = Bikes;

            switch (SortOrder)
            {
                case "price_desc":
                    result = Bikes.OrderByDescending(b => b.Price);
                    break;
                default:
                    result = Bikes.OrderBy(b => b.Price);
                    break;
            }

            return result;
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
