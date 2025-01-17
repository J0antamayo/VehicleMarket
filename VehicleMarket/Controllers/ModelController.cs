﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleMarket.Controllers.Resources;
using VehicleMarket.Interfaces;
using VehicleMarket.Models;
using VehicleMarket.ViewModels;

namespace VehicleMarket.Controllers
{
    [Authorize(Roles = "Admin, Executive")]
    public class ModelController : Controller
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMakeRepository _makeRepository;
        private readonly IMapper _mapper;

        [BindProperty]
        public ModelViewModel ModelVM { get; set; }

        public ModelController(IModelRepository modelRepository, IMakeRepository makeRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _makeRepository = makeRepository;
            ModelVM = new ModelViewModel
            {
                Makes = _makeRepository.GetMakeList(),
                Model = new Model()
            };
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Model> Models = await _modelRepository.GetAll();
            return View(Models);
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Model = await _modelRepository.GetByIdAsync(id);
            if (Model == null)
            {
                return NotFound();
            }
            ModelVM.Model = Model;
            return View(ModelVM);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (ModelState.IsValid)
            {
                _modelRepository.Update(ModelVM.Model);
                return RedirectToAction(nameof(Index));
            }

            return View(ModelVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Model = await _modelRepository.GetByIdAsync(id);
            if (Model == null)
            {
                return NotFound();
            }
            _modelRepository.Delete(Model);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet("api/models/{MakeId}")]
        public IEnumerable<ModelResource> ModelsByMake(int MakeId)
        {
            var models = _modelRepository.GetByMakeId(MakeId);
            return _mapper.Map<List<Model>, List<ModelResource>>(models.ToList());
        }

        [AllowAnonymous]
        [HttpGet("api/models")]
        public IEnumerable<ModelResource> Models()
        {
            var models = _modelRepository.GetModelList();

            return _mapper.Map<List<Model>, List<ModelResource>>(models.ToList());
        }
    }
}
