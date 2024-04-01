using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.VideoDtos;

namespace Villa.WebUI.Areas.Vitrin.ViewComponents.Default
{
    public class _UIDefaultVideoComponentPartial : ViewComponent
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public _UIDefaultVideoComponentPartial(IVideoService videoService, IMapper mapper)
        {
            _videoService = videoService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<ResultVideoDto>>(await _videoService.TGetAllAsync()));
        }
    }
}
