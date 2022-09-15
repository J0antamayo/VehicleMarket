using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleMarket.Interfaces;
using VehicleMarket.Models;

namespace VehicleMarket.Controllers
{
    [Authorize(Roles = "Admin,Executive")]
    public class MakeController : Controller
    {
        public readonly IMakeRepository _makeRepository;

        public MakeController(IMakeRepository makeRepository)
        {
            _makeRepository = makeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Make> makes = await _makeRepository.GetAll();
            return View(makes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Make make)
        {
            if (ModelState.IsValid)
            {
                _makeRepository.Add(make);
                return RedirectToAction(nameof(Index));
            }

            return View(make);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var make = await _makeRepository.GetByIdAsync(id);
            if (make == null)
            {
                return NotFound();
            }
            return View(make);
        }

        [HttpPost]
        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                _makeRepository.Update(make);
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var make = await _makeRepository.GetByIdAsync(id);
            if (make == null)
            {
                return NotFound();
            }
            _makeRepository.Delete(make);
            return RedirectToAction(nameof(Index));
        }

    }
}
