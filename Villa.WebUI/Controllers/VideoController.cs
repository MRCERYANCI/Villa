using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusniessLayer.Abstract;
using Villa.BusniessLayer.ValidationRules.VideoRules;
using Villa.DtoLayer.Dtos.VideoDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public VideoController(IVideoService VideoService, IMapper mapper)
        {
            _videoService = VideoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Controller"] = "Video";
            TempData["Action"] = "Index";

            var values = _mapper.Map<List<ResultVideoDto>>(await _videoService.TGetAllAsync());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateVideo()
        {
            TempData["Controller"] = "Video";
            TempData["Action"] = "Create Video";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVideo(CreateVideoDto createVideoDto)
        {
            ModelState.Clear();

            VideoValidator VideoValidator = new VideoValidator();
            ValidationResult validationResult = VideoValidator.Validate(_mapper.Map<Video>(createVideoDto));

            if (validationResult.IsValid)
            {

                var NewVideoDto = _mapper.Map<Video>(createVideoDto);
                await _videoService.TCreateAsync(NewVideoDto);
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

        public async Task<IActionResult> DeleteVideo(ObjectId id)
        {
            await _videoService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVideo(ObjectId id)
        {
            TempData["Controller"] = "Video";
            TempData["Action"] = "Update Video";

            return View(_mapper.Map<UpdateVideoDto>(await _videoService.TGetByIdAsync(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVideo(UpdateVideoDto updateVideoDto)
        {
            ModelState.Clear();

            VideoValidator VideoValidator = new VideoValidator();
            ValidationResult validationResult = VideoValidator.Validate(_mapper.Map<Video>(updateVideoDto));

            if (validationResult.IsValid)
            {
                var Video = _mapper.Map<Video>(updateVideoDto);
                await _videoService.TUpdateAsync(Video);
                return RedirectToAction("Index");
            }
            else
            {
                validationResult.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View(_mapper.Map<UpdateVideoDto>(await _videoService.TGetByIdAsync(updateVideoDto.Id)));
            }
        }
    }
}
