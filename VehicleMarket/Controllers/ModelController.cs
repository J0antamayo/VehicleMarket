using Microsoft.AspNetCore.Mvc;
using VehicleMarket.Interfaces;
using VehicleMarket.Models;
using VehicleMarket.ViewModels;

namespace VehicleMarket.Controllers
{
    public class ModelController : Controller
    {
        [BindProperty]
        public ModelViewModel ModelVM { get; set; }

        private readonly IModelRepository _modelRepository;
        private readonly IMakeRepository _makeRepository;

        public ModelController(IModelRepository modelRepository, IMakeRepository makeRepository)
        {
            _modelRepository = modelRepository;
            _makeRepository = makeRepository;

            ModelVM = new ModelViewModel()
            {
                Makes = _makeRepository.GetAll(),
                Model = new Model()
            };
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
