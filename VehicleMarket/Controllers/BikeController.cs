using Microsoft.AspNetCore.Mvc;

namespace VehicleMarket.Controllers
{
    public class BikeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
