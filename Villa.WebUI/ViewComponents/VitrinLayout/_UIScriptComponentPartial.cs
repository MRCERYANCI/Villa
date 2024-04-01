using Microsoft.AspNetCore.Mvc;
namespace Villa.WebUI.ViewComponents.VitrinLayout
{
    public class _UIScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
