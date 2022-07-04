using Microsoft.AspNetCore.Mvc;

namespace YemekTarifiSitesi.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string r)
        {
            return View();
        }
    }
}
