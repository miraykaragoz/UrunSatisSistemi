using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
