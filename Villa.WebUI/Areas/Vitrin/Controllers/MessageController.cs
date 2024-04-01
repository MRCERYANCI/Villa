using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.MessageDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Areas.Vitrin.Controllers
{
    [AllowAnonymous]
    [Area("Vitrin")]
    [Route("Vitrin/Message")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService MessageService, IMapper mapper)
        {
            _messageService = MessageService;
            _mapper = mapper;
        }

        [Route("CreateMessageJson")]
        [HttpPost]
        public async Task<JsonResult> CreateMessageJson(CreateMessageDto createMessageDto)
        {
            if (createMessageDto != null)
            {
                await _messageService.TCreateAsync(_mapper.Map<Message>(createMessageDto));
                return Json("1");
            }

            return Json("0");
        }
    }
}
