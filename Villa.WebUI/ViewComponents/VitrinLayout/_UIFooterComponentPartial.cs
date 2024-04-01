using Microsoft.AspNetCore.Mvc;
namespace Villa.WebUI.ViewComponents.VitrinLayout
{
    public class _UIFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
