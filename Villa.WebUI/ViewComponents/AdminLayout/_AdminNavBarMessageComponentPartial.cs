using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.MessageDtos;

namespace Villa.WebUI.ViewComponents.AdminLayout
{
    public class _AdminNavBarMessageComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public _AdminNavBarMessageComponentPartial(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<ResultMessageDto>>(await _messageService.TLastFiveList(x => x.CreatedDate, 5)));
        }
    }
}
