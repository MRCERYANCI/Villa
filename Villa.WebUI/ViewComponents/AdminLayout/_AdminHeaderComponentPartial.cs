﻿using Microsoft.AspNetCore.Mvc;
namespace Villa.WebUI.ViewComponents.AdminLayout
{
    public class _AdminHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
