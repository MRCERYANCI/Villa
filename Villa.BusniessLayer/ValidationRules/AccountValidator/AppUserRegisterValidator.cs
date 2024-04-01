using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.DtoLayer.Dtos.RegisterDtos;

namespace Villa.BusniessLayer.ValidationRules.AccountValidator
{
    public class AppUserRegisterValidator : AbstractValidator<CreateRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Ad Alanını Boş Bırakmayınız");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen Soyad Alanını Boş Bırakmayınız");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen Mail Alanını Boş Bırakmayınız");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen Şifre Alanını Boş Bırakmayınız");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Lütfen Telefon Alanını Boş Bırakmayınız");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen Şifre Tekrar Alanını Boş Bırakmayınız");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen Geçerli Mail Adresi Giriniz");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Şifreler Birbirleriyle Eşleşmiyor");
        }
    }
}
