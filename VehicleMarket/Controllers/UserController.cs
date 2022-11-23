using Microsoft.AspNetCore.Mvc;

namespace VehicleMarket.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
