using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.DtoLayer.Dtos.LoginDtos;

namespace Villa.BusniessLayer.ValidationRules.AccountValidator
{
    public class AppUserLoginValidator : AbstractValidator<CreateLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu Alan Zorunludur*");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Bu Alan Zorunludur*");
        }
    }
}
