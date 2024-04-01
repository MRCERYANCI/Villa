using Microsoft.AspNetCore.Identity;

namespace Villa.WebUI.Models
{
    public class CustomerIdentityValidator : IdentityErrorDescriber
    {
        //Override:Benim metodumun işleyişini aynı şekilde bırakıyor ama içeriği benim istediğim formata çeviriyor

        public override IdentityError PasswordTooShort(int length)  //Şifre çok kısa girildiği zaman bu metod devreye girecek
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola en az {length} karakter olmalıdır"
            };
        }

        public override IdentityError PasswordRequiresUpper()  //Şifrede büyük harf kullanılmassa bu metod devreye girecek
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Lütfen en az 1 büyük harf giriniz"
            };
        }
        public override IdentityError PasswordRequiresLower()  //Şifrede küçük harf kullanılmassa bu metod devreye girecek
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Lütfen en az 1 küçük harf giriniz"
            };
        }

        public override IdentityError PasswordRequiresDigit()  //Şifrede rakam kullanılmassa bu metod devreye girecek
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Lütfen en az rakam giriniz"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()  //Şifrede sembol kullanılmassa bu metod devreye girecek
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Lütfen en az bir sembol ifadesi giriniz"
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"{email} bu mail adresi saten kullanılmaktadır lütfen başka bir mail adresi giriniz"
            };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError()
            {
                Code = "InvalidEmail",
                Description = $"{email} bu mail adresi geçersizdir lütfen geçerli bir mail adresi giriniz"
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"{userName} bu kullanıcı adı saten kullanılmaktadır lütfen başka bir kullanıcı adı giriniz"
            };
        }
    }
}
