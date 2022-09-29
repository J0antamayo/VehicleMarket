using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleMarket.Interfaces;
using VehicleMarket.Models;
using VehicleMarket.ViewModels;

namespace VehicleMarket.Controllers
{
    [Authorize(Roles = "Admin, Executive")]
    public class BikeController : Controller
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IMakeRepository _makeRepository;
        private readonly ICurrecyRepository _currecyRepository;


        [BindProperty]
        public BikeViewModel BikeVM { get; set; }

        public BikeController(IMakeRepository makeRepository, IModelRepository modelRepository, ICurrecyRepository currecyRepository, IBikeRepository bikeRepository)
        {
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
            _currecyRepository = currecyRepository;
            _bikeRepository = bikeRepository;

            BikeVM = new BikeViewModel
            {
                Makes = _makeRepository.GetMakeList(),
                Models = _modelRepository.GetModelList(),
                Currencies = _currecyRepository.GetCurrencyList(),
                Bike = new Bike()
            };

        }

        [HttpGet]
        public IActionResult Index(string SearchString, string SortOrder, int PageNumber = 1, int PageSize = 2)
        {
            ViewBag.PriceSortParam = String.IsNullOrEmpty(SortOrder) ? "price_desc" : "";

            var result = _bikeRepository.GetBikes(PageSize, PageNumber, SortOrder, SearchString);

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(BikeVM);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (ModelState.IsValid)
            {
                _bikeRepository.Add(BikeVM.Bike);

                var files = HttpContext.Request.Form.Files;
                _bikeRepository.UploadImage(BikeVM.Bike, files);

                return RedirectToAction(nameof(Index));
            }

            return View(BikeVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var bike = await _bikeRepository.GetByIdAsync(Id);
            if (bike == null)
            {
                return NotFound();
            }
            BikeVM.Bike = bike;
            return View(BikeVM);
        }

        //[HttpPost, ActionName("Edit")]
        //public IActionResult EditPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _modelRepository.Update(ModelVM.Model);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(ModelVM);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var Model = await _modelRepository.GetByIdAsync(id);
        //    if (Model == null)
        //    {
        //        return NotFound();
        //    }
        //    _modelRepository.Delete(Model);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}

