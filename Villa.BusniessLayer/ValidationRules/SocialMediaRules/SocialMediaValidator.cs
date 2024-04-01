using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.EntityLayer.Entities;

namespace Villa.BusniessLayer.ValidationRules.SocialMediaRules
{
    public class SocialMediaValidator : AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Bu Alan Zorunludur*");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Bu Alan Zorunludur*");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu Alan Zorunludur*");
            RuleFor(x => x.Title).MinimumLength(2).WithMessage("Bu Alan En Az 2 Karakter Veri Girişi Yapınız*");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Bu Alan En Fazla 50 Karakter Veri Girişi Yapınız*");
            RuleFor(x => x.Url).MinimumLength(10).WithMessage("Bu Alan En Az 10 Karakter Veri Girişi Yapınız*");
            RuleFor(x => x.Icon).MinimumLength(10).WithMessage("Bu Alan En Az 10 Karakter Veri Girişi Yapınız*");
            RuleFor(x => x.Icon).MaximumLength(100).WithMessage("Bu Alan En Fazla 100 Karakter Veri Girişi Yapınız*");
            RuleFor(x => x.Url).MaximumLength(250).WithMessage("Bu Alan En Fazla 250 Karakter Veri Girişi Yapınız*");
        }
    }
}
