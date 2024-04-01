using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.ViewComponents.VitrinLayout
{
    public class _UIHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
