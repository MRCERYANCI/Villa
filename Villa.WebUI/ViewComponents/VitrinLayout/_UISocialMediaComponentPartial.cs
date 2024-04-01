using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.SocialMediaDtos;

namespace Villa.WebUI.ViewComponents.VitrinLayout
{
    public class _UISocialMediaComponentPartial : ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public _UISocialMediaComponentPartial(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<ResultSocialMediaDto>>(await _socialMediaService.TGetAllAsync()));
        }
    }
}
