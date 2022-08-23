using Microsoft.AspNetCore.Mvc;
using VehicleMarket.Interfaces;
using VehicleMarket.Models;
using VehicleMarket.ViewModels;

namespace VehicleMarket.Controllers
{
    public class ModelController : Controller
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMakeRepository _makeRepository;

        public ModelController(IModelRepository modelRepository, IMakeRepository makeRepository)
        {
            _modelRepository = modelRepository;
            _makeRepository = makeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Model> models = await _modelRepository.GetAll();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var CreateModelViewModel = new CreateModelViewModel
            {
                Model = new Model(),
                Makes = _makeRepository.GetMakeList()
            };
            return View(CreateModelViewModel);
        }
    }
}
