using carList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BusinessLogic.Interfaces;

namespace carList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService service;

        public HomeController(ICarService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.GetAll());

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
