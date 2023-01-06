using AspNetProjekt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetProjekt.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}