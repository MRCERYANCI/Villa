using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.ContactDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Controller"] = "Contact";
            TempData["Action"] = "Index";

            return View(_mapper.Map<List<ResultContactDto>>(await _contactService.TGetAllAsync()));
        }

        public async Task<IActionResult> DeleteContact(ObjectId id)
        {
            await _contactService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(ObjectId id)
        {
            TempData["Controller"] = "Contact";
            TempData["Action"] = "Update Contact";

            return View(_mapper.Map<UpdateContactDto>(await _contactService.TGetByIdAsync(id)));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContact)
        {
            await _contactService.TUpdateAsync(_mapper.Map<Contact>(updateContact));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            TempData["Controller"] = "Contact";
            TempData["Action"] = "Create Contact";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContact)
        {
            await _contactService.TCreateAsync(_mapper.Map<Contact>(createContact));
            return RedirectToAction("Index");
        }
    }
}
