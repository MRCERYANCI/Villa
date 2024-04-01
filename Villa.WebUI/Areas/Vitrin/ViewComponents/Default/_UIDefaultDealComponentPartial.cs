using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.DealsDtos;

namespace Villa.WebUI.Areas.Vitrin.ViewComponents.Default
{
    public class _UIDefaultDealComponentPartial : ViewComponent
    {
        private readonly IDealService _dealService;
        private readonly IMapper _mapper;

        public _UIDefaultDealComponentPartial(IDealService dealService, IMapper mapper)
        {
            _dealService = dealService;
            _mapper = mapper;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<ResultDealsDto>>(await _dealService.TGetAllAsync()));
        }
    }
}
