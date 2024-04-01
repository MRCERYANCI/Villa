using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.ProductDtos;

namespace Villa.WebUI.Areas.Vitrin.ViewComponents.Default
{
    public class _UIDefaultProductComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public _UIDefaultProductComponentPartial(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<ResultProductDto>>(await _productService.TGetAllAsync()));
        }
    }
}
