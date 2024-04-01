using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.CounterDtos;

namespace Villa.WebUI.Areas.Vitrin.ViewComponents.Default
{
    public class _UIDefaultCounterComponentPartial : ViewComponent
    {
        private readonly ICounterService _counterService;
        private readonly IMapper _mapper;

        public _UIDefaultCounterComponentPartial(ICounterService counterService, IMapper mapper)
        {
            _counterService = counterService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<ResultCounterDto>>(await _counterService.TGetAllAsync()));
        }
    }
}
