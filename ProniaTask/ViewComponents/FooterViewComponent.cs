﻿using Microsoft.AspNetCore.Mvc;

namespace ProniaTask.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}