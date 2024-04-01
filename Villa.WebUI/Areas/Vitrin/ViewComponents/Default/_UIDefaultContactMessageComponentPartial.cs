using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.Areas.Vitrin.ViewComponents.Default
{
    public class _UIDefaultContactMessageComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
