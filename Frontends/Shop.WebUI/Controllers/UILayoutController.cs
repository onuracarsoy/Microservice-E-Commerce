﻿using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
