using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.DealsDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
    public class DealController : Controller
    {
        private readonly IDealService _dealService;
        private readonly IMapper _mapper;

        public DealController(IDealService dealService, IMapper mapper)
        {
            _dealService = dealService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Controller"] = "Deal";
            TempData["Action"] = "Index";

            return View(_mapper.Map<List<ResultDealsDto>>(await _dealService.TGetAllAsync()));
        }

        public async Task<IActionResult> DeleteDeal(ObjectId id)
        {
            await _dealService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDeal(ObjectId id)
        {
            TempData["Controller"] = "Deal";
            TempData["Action"] = "Update Deal";

            return View(_mapper.Map<UpdateDealsDto>(await _dealService.TGetByIdAsync(id)));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDeal(UpdateDealsDto updateDeal)
        {
            await _dealService.TUpdateAsync(_mapper.Map<Deal>(updateDeal));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateDeal()
        {
            TempData["Controller"] = "Deal";
            TempData["Action"] = "Create Deal";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDeal(CreateDealsDto createDeal)
        {
            await _dealService.TCreateAsync(_mapper.Map<Deal>(createDeal));
            return RedirectToAction("Index");
        }
    }
}
