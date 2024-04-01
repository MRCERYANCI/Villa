using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.FeatureDtos;

using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Controller"] = "Feature";
            TempData["Action"] = "Index";

            return View(_mapper.Map<List<ResultFeatureDto>>(await _featureService.TGetAllAsync()));
        }

        public async Task<IActionResult> DeleteFeature(ObjectId id)
        {
            await _featureService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(ObjectId id)
        {
            TempData["Controller"] = "Feature";
            TempData["Action"] = "Update Feature";

            return View(_mapper.Map<UpdateFeatureDto>(await _featureService.TGetByIdAsync(id)));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeature)
        {
            await _featureService.TUpdateAsync(_mapper.Map<Feature>(updateFeature));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            TempData["Controller"] = "Feature";
            TempData["Action"] = "Create Feature";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeature)
        {
            await _featureService.TCreateAsync(_mapper.Map<Feature>(createFeature));
            return RedirectToAction("Index");
        }
    }
}
