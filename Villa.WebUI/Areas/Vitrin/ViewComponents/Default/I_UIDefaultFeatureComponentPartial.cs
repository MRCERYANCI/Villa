using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.Areas.Vitrin.ViewComponents.Default
{
    public interface I_UIDefaultFeatureComponentPartial
    {
        Task<IViewComponentResult> InvokeAsync();
    }
}