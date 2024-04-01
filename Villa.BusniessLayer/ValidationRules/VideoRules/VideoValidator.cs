using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.EntityLayer.Entities;

namespace Villa.BusniessLayer.ValidationRules.VideoRules
{
    public class VideoValidator : AbstractValidator<Video>
    {
        public VideoValidator()
        {
            RuleFor(x => x.VideoUrl).NotEmpty().WithMessage("Bu Alan Zorunludur*");
            RuleFor(x => x.CoverImage).NotEmpty().WithMessage("Bu Alan Zorunludur*");
            RuleFor(x => x.VideoUrl).MinimumLength(10).WithMessage("Bu Alana En Az 10 Karakterlik Veri Girişi Yapınız*");
            RuleFor(x => x.VideoUrl).MaximumLength(500).WithMessage("Bu Alana En Fazla 500 Karakterlik Veri Girişi Yapınız*");
        }
    }
}
