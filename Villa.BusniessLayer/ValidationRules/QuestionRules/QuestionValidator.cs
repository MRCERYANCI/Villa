using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.EntityLayer.Entities;

namespace Villa.BusniessLayer.ValidationRules.QuestionRules
{
    public class QuestionValidator : AbstractValidator<Quest>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.Answer).NotEmpty().WithMessage("Bu Alan Zorunludur*");
            RuleFor(x => x.Question).NotEmpty().WithMessage("Bu Alan Zorunludur*");
            RuleFor(x => x.Question).MinimumLength(10).WithMessage("Bu Alana En Az 10 Karakter Veri Girişi Yapınız*");
            RuleFor(x => x.Answer).MinimumLength(10).WithMessage("Bu Alana En Az 10 Karakter Veri Girişi Yapınız*");
            RuleFor(x => x.Answer).MaximumLength(1000).WithMessage("Bu Alana En Fazla 1000 Karakter Veri Girişi Yapınız*");
        }
    }
}
