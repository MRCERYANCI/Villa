using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.BannerDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;

        public BannerController(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Controller"] = "Banner";
            TempData["Action"] = "Index";

            var values = _mapper.Map<List<ResultBannerDto>>(await _bannerService.TGetAllAsync());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBanner()
        {
            TempData["Controller"] = "Banner";
            TempData["Action"] = "Create Banner";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var NewBannerDto = _mapper.Map<Banner>(createBannerDto);
            await _bannerService.TCreateAsync(NewBannerDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBanner(ObjectId id)
        {
            await _bannerService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetBannerById(ObjectId id)
        {
            return View(_mapper.Map<UpdateBannerDto>(await _bannerService.TGetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            var banner = _mapper.Map<Banner>(updateBannerDto);
            await _bannerService.TUpdateAsync(banner);
            return RedirectToAction("Index");
        } 
    }
}
