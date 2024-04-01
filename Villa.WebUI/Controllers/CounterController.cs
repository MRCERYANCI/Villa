using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.ContactDtos;
using Villa.DtoLayer.Dtos.CounterDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
    public class CounterController : Controller
    {
        private readonly ICounterService _counterService;
        private readonly IMapper _mapper;

        public CounterController(ICounterService counterService, IMapper mapper)
        {
            _counterService = counterService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Controller"] = "Counter";
            TempData["Action"] = "Index";

            return View(_mapper.Map<List<ResultCounterDto>>(await _counterService.TGetAllAsync()));
        }

        public async Task<IActionResult> DeleteCounter(ObjectId id)
        {
            await _counterService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCounter(ObjectId id)
        {
            TempData["Controller"] = "Counter";
            TempData["Action"] = "Update Counter";

            return View(_mapper.Map<UpdateCounterDto>(await _counterService.TGetByIdAsync(id)));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCounter(UpdateCounterDto updateCounter)
        {
            await _counterService.TUpdateAsync(_mapper.Map<Counter>(updateCounter));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCounter()
        {
            TempData["Controller"] = "Counter";
            TempData["Action"] = "Create Counter";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCounter(CreateCounterDto createCounter)
        {
            await _counterService.TCreateAsync(_mapper.Map<Counter>(createCounter));
            return RedirectToAction("Index");
        }
    }
}
