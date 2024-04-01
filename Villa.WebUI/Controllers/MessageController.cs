using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.MessageDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService MessageService, IMapper mapper)
        {
            _messageService = MessageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Controller"] = "Message";
            TempData["Action"] = "Index";

            return View(_mapper.Map<List<ResultMessageDto>>(await _messageService.TGetAllAsync()));
        }

        public async Task<IActionResult> DeleteMessage(ObjectId id)
        {
            await _messageService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetail(ObjectId id)
        {
            TempData["Controller"] = "Message";
            TempData["Action"] = "Message Detail";

            return View(_mapper.Map<UpdateMessageDto>(await _messageService.TGetByIdAsync(id)));
        }
        

        [HttpGet]
        public IActionResult CreateMessage()
        {
            TempData["Controller"] = "Message";
            TempData["Action"] = "Create Message";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessage)
        {
            await _messageService.TCreateAsync(_mapper.Map<Message>(createMessage));
            return RedirectToAction("Index");
        }


    }
}

