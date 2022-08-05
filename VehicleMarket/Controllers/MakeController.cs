using Microsoft.AspNetCore.Mvc;
using VehicleMarket.AppDBContext;

namespace VehicleMarket.Controllers
{
    public class MakeController : Controller
    {
        private readonly VehicleMarketDbContext _vehicleMarketDb;
        public MakeController(VehicleMarketDbContext vehicleMarketDb)
        {
            _vehicleMarketDb = vehicleMarketDb;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
