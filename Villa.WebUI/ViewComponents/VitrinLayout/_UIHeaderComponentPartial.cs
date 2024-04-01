using Microsoft.AspNetCore.Mvc;
namespace Villa.WebUI.ViewComponents.VitrinLayout
{
    public class _UIHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
