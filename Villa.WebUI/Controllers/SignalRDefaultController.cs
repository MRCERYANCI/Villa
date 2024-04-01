using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
