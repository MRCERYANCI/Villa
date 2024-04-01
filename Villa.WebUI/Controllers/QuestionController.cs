using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusniessLayer.Abstract;
using Villa.BusniessLayer.ValidationRules.QuestionRules;
using Villa.DtoLayer.Dtos.QuestDtos;
using Villa.EntityLayer.Entities;
using FluentValidation.Results;

namespace Villa.WebUI.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestService _questionService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestService QuestionService, IMapper mapper)
        {
            _questionService = QuestionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Controller"] = "Question";
            TempData["Action"] = "Index";

            var values = _mapper.Map<List<ResultQuestDto>>(await _questionService.TGetAllAsync());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateQuestion()
        {
            TempData["Controller"] = "Question";
            TempData["Action"] = "Create Question";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuestion(CreateQuestDto createQuestionDto)
        {
            ModelState.Clear();

            QuestionValidator questionValidator = new QuestionValidator();
            ValidationResult validationResult = questionValidator.Validate(_mapper.Map<Quest>(createQuestionDto));

            if (validationResult.IsValid)
            {

                var NewQuestionDto = _mapper.Map<Quest>(createQuestionDto);
                await _questionService.TCreateAsync(NewQuestionDto);
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

        public async Task<IActionResult> DeleteQuestion(ObjectId id)
        {
            await _questionService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateQuestion(ObjectId id)
        {
            TempData["Controller"] = "Question";
            TempData["Action"] = "Update Question";

            return View(_mapper.Map<UpdateQuestDto>(await _questionService.TGetByIdAsync(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestDto updateQuestionDto)
        {
            ModelState.Clear();

            QuestionValidator questionValidator = new QuestionValidator();
            ValidationResult validationResult = questionValidator.Validate(_mapper.Map<Quest>(updateQuestionDto));

            if (validationResult.IsValid)
            {
                var Question = _mapper.Map<Quest>(updateQuestionDto);
                await _questionService.TUpdateAsync(Question);
                return RedirectToAction("Index");
            }
            else
            {
                validationResult.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View(_mapper.Map<UpdateQuestDto>(await _questionService.TGetByIdAsync(updateQuestionDto.Id)));
            }
        }
    }
}
