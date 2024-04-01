using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.FeatureDtos;

namespace Villa.WebUI.Areas.Vitrin.ViewComponents.Default
{
    public class _UIDefaultFeatureComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public _UIDefaultFeatureComponentPartial(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<ResultFeatureDto>>(await _featureService.TGetAllAsync()));
        }
    }
}
