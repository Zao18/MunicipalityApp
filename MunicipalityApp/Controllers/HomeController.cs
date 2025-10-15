using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Data;
using MunicipalityApp.Models;
using System.Diagnostics;

namespace MunicipalityApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventRepository _repository;

        public HomeController(ILogger<HomeController> logger, EventRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var upcomingEvents = _repository.GetAll()
                .Where(e => e.Date >= DateTime.Today)
                .OrderBy(e => e.Date)
                .Take(3)
                .ToList();

            return View(upcomingEvents);
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
    }
}

