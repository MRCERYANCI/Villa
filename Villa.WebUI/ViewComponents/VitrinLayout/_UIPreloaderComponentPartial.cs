using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.ViewComponents.VitrinLayout
{
    public class _UIPreloaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
