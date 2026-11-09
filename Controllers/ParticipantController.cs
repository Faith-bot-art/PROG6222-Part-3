using Microsoft.AspNetCore.Mvc;
using RaceDay.MVC.Models;
using RaceDay.MVC.Services;

namespace RaceDay.MVC.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly ApiService _apiService;

        public ParticipantController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // POST: /Participant/Enrol
        [HttpPost]
        public async Task<IActionResult> Enrol(int eventId, int categoryId)
        {
            // Check if user is logged in
            var token = HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            // Data to send to API
            var enrolData = new { EventId = eventId, CategoryId = categoryId };

            // Call the API
            var response = await _apiService.PostAsync("enrolments", enrolData);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Successfully enrolled in the event!";
                return RedirectToAction("MyEnrolments");
            }

            TempData["Error"] = "Failed to enrol. You might already be enrolled.";
            return RedirectToAction("Index", "Home");
        }

        // GET: /Participant/MyEnrolments
        public async Task<IActionResult> MyEnrolments()
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(token)) return RedirectToAction("Login", "Account");

            var enrolments = await _apiService.GetAsync<List<EnrolmentDto>>("enrolments");
            return View(enrolments ?? new List<EnrolmentDto>());
        }
    }
}