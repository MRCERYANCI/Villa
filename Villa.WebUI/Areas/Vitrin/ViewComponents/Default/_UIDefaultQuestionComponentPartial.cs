using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.Abstract;
using Villa.DtoLayer.Dtos.QuestDtos;

namespace Villa.WebUI.Areas.Vitrin.ViewComponents.Default
{
    public class _UIDefaultQuestionComponentPartial : ViewComponent
    {
        private readonly IQuestService _questService;
        private readonly IMapper _mapper;
        public _UIDefaultQuestionComponentPartial(IQuestService questService, IMapper mapper)
        {
            _questService = questService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_mapper.Map<List<ResultQuestDto>>(await _questService.TGetAllAsync()));
        }
    }
}
