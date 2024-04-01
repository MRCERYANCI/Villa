using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.ContactDtos;

namespace Villa.WebUI.Areas.Vitrin.ViewComponents.Default
{
    public class _UIDefaultContactComponentPartial : ViewComponent
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public _UIDefaultContactComponentPartial(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<ResultContactDto>>(await _contactService.TGetAllAsync()));
        }
    }
}
