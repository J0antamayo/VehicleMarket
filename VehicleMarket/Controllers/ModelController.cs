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

        [BindProperty]
        public ModelViewModel ModelVM { get; set; }

        public ModelController(IModelRepository modelRepository, IMakeRepository makeRepository)
        {
            _modelRepository = modelRepository;
            _makeRepository = makeRepository;
            ModelVM = new ModelViewModel
            {
                Makes = _makeRepository.GetMakeList(),
                Model = new Model()
            };
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
            return View(ModelVM);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (ModelState.IsValid)
            {
                _modelRepository.Add(ModelVM.Model);
                return RedirectToAction(nameof(Index));
            }

            return View(ModelVM);

        }
    }
}
