using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RaceDay.MVC.Models;
using RaceDay.MVC.Services;

namespace RaceDay.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _apiService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApiService apiService, ILogger<HomeController> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        // GET: /Home/Index
        public async Task<IActionResult> Index()
        {
            // Fetch all events from the API
            var events = await _apiService.GetAsync<List<EventDto>>("events");
            return View(events ?? new List<EventDto>());
        }

        // GET: /Home/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Fetch the event
            var ev = await _apiService.GetAsync<EventDto>($"events/{id}");
            if (ev == null) return NotFound();

            // Fetch the categories for this event
            var categories = await _apiService.GetAsync<List<CategoryDto>>($"categories/event/{id}");

            // Pass data to the view
            ViewBag.Categories = categories ?? new List<CategoryDto>();

            return View(ev);
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