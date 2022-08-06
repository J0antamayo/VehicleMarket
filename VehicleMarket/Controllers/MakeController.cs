using Microsoft.AspNetCore.Mvc;
using VehicleMarket.Interfaces;
using VehicleMarket.Models;

namespace VehicleMarket.Controllers
{
    public class MakeController : Controller
    {
        public readonly IMakeRepository _makeRepository;

        public MakeController(IMakeRepository makeRepository)
        {
            _makeRepository = makeRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Make> makes = await _makeRepository.GetAll();
            return View(makes);
        }
    }
}
