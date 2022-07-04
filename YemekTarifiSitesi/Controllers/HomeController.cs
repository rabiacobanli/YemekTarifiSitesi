using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YemekTarifiSitesi.Models;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;

namespace YemekTarifiSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly YemekTarifiSitesiContext _context;

        private readonly ILogger<HomeController> _logger;

        private readonly IStringLocalizer<HomeController> _localizer;
        
        public HomeController(YemekTarifiSitesiContext context, ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = _localizer.GetString("Message");
            var yemekList = _context.Yemek;
            return View();
        }

        public IActionResult Tarifler()
        {
            var model = new YemekTarifModel();
            model.Yemek = _context.Yemek.ToList();
            model.Malzeme = _context.Malzeme.ToList();
            model.YemekKategori = _context.YemekKategori.ToList();
            model.YemekMalzeme = _context.YemekMalzeme.ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //public IActionResult Tarifler()
        //{
        //    var model = new YemekTarifModel();
        //    model.Yemek = _context.Yemek.ToList();
        //    model.Malzeme = _context.Malzeme.ToList();
        //    model.YemekKategori = _context.YemekKategori.ToList();
        //    model.YemekMalzeme = _context.YemekMalzeme.ToList();
        //    return View(model);
        //}

    }
}
