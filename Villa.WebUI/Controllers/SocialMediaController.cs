using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusniessLayer.Abstract;
using Villa.BusniessLayer.ValidationRules.SocialMediaRules;
using Villa.DtoLayer.Dtos.SocialMediaDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService SocialMediaService, IMapper mapper)
        {
            _socialMediaService = SocialMediaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Controller"] = "SocialMedia";
            TempData["Action"] = "Index";

            var values = _mapper.Map<List<ResultSocialMediaDto>>(await _socialMediaService.TGetAllAsync());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSocialMedia()
        {
            TempData["Controller"] = "SocialMedia";
            TempData["Action"] = "Create SocialMedia";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            ModelState.Clear();

            SocialMediaValidator SocialMediaValidator = new SocialMediaValidator();
            ValidationResult validationResult = SocialMediaValidator.Validate(_mapper.Map<SocialMedia>(createSocialMediaDto));

            if (validationResult.IsValid)
            {

                var NewSocialMediaDto = _mapper.Map<SocialMedia>(createSocialMediaDto);
                await _socialMediaService.TCreateAsync(NewSocialMediaDto);
                return RedirectToAction("Index");
            }
            else
            {
                validationResult.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
        }

        public async Task<IActionResult> DeleteSocialMedia(ObjectId id)
        {
            await _socialMediaService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(ObjectId id)
        {
            TempData["Controller"] = "SocialMedia";
            TempData["Action"] = "Update SocialMedia";

            return View(_mapper.Map<UpdateSocialMediaDto>(await _socialMediaService.TGetByIdAsync(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            ModelState.Clear();

            SocialMediaValidator SocialMediaValidator = new SocialMediaValidator();
            ValidationResult validationResult = SocialMediaValidator.Validate(_mapper.Map<SocialMedia>(updateSocialMediaDto));

            if (validationResult.IsValid)
            {
                var SocialMedia = _mapper.Map<SocialMedia>(updateSocialMediaDto);
                await _socialMediaService.TUpdateAsync(SocialMedia);
                return RedirectToAction("Index");
            }
            else
            {
                validationResult.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View(_mapper.Map<UpdateSocialMediaDto>(await _socialMediaService.TGetByIdAsync(updateSocialMediaDto.Id)));
            }
        }
    }
}
