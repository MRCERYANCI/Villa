using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.ContactDtos;
namespace Villa.WebUI.ViewComponents.VitrinLayout
{
    public class _UISubHeaderComponentPartial : ViewComponent
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public _UISubHeaderComponentPartial(IContactService contactService, IMapper mapper)
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
