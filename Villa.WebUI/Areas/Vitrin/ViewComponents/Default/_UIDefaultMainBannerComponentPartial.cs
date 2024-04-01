using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.BannerDtos;

namespace Villa.WebUI.Areas.Vitrin.ViewComponents.Default
{
    public class _UIDefaultMainBannerComponentPartial : ViewComponent
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;

        public _UIDefaultMainBannerComponentPartial(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<ResultBannerDto>>(await _bannerService.TGetAllAsync()));
        }
    }
}
