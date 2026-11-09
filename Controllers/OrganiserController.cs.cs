using Microsoft.AspNetCore.Mvc;
using RaceDay.MVC.Models;
using RaceDay.MVC.Services;

namespace RaceDay.MVC.Controllers
{
    public class OrganiserController : Controller
    {
        private readonly ApiService _apiService;

        public OrganiserController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(token)) return RedirectToAction("Login", "Account");

            // Get events created by this organiser
            var events = await _apiService.GetAsync<List<EventDto>>("events/my-events");
            return View(events ?? new List<EventDto>());
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto model, IFormFile? bannerFile)
        {
            if (!ModelState.IsValid) return View(model);

            // 1. Create the event
            var response = await _apiService.PostAsync("events", model);

            if (response.IsSuccessStatusCode)
            {
                // Read the created event to get its ID
                var createdEvent = await response.Content.ReadFromJsonAsync<EventDto>();

                // 2. If an image was uploaded, send it to the API
                if (bannerFile != null && bannerFile.Length > 0 && createdEvent != null)
                {
                    await _apiService.PostFileAsync($"events/{createdEvent.EventId}/banner", bannerFile);
                }

                TempData["Success"] = "Event created successfully!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to create event.");
            return View(model);
        }
    }
}