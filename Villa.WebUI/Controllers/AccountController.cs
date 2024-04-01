using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Villa.BusniessLayer.ValidationRules.AccountValidator;
using Villa.DtoLayer.Dtos.LoginDtos;
using Villa.DtoLayer.Dtos.RegisterDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateRegisterDto createRegisterDto)
        {
            ModelState.Clear();

            AppUserRegisterValidator appuser = new AppUserRegisterValidator();
            ValidationResult validationResult = appuser.Validate(createRegisterDto);

            if(validationResult.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = createRegisterDto.UserName,
                    Name = createRegisterDto.Name,
                    Surname = createRegisterDto.Surname,
                    Email = createRegisterDto.Email,
                    PhoneNumber = createRegisterDto.PhoneNumber             
                };

                var result = await _userManager.CreateAsync(appUser, createRegisterDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                validationResult.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(CreateLoginDto createLoginDto)
        {
            ModelState.Clear();

            AppUserLoginValidator appuser = new AppUserLoginValidator();
            ValidationResult validationResult = appuser.Validate(createLoginDto);

            if(validationResult.IsValid)
            {
                var user = await _userManager.FindByNameAsync(createLoginDto.UserName);
                if(user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Adı ve/veya Şifre Yanlış");
                    return View();
                }

                var result = await _signInManager.PasswordSignInAsync(user, createLoginDto.Password, true,true);
                if(!result.Succeeded)
                {
                    ModelState.AddModelError("", "Kullanıcı Adı ve/veya Şifre Yanlış");
                    return View();
                }

                return RedirectToAction("Index", "Banner");

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

        public async Task<IActionResult> LogOut()
        {
            TempData["JSON"] = "";
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
