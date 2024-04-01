using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.Areas.Vitrin.Controllers
{
    [AllowAnonymous]
    [Area("Vitrin")]
    [Route("Vitrin/Default")]
    public class DefaultController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
