﻿using Microsoft.AspNetCore.Mvc;

namespace YemekTarifiSitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
