using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Data;
using MunicipalityApp.Models;
using MunicipalityApp.Services;
using System;
using System.Linq;

namespace MunicipalityApp.Controllers
{
    public class EventsController : Controller
    {
        // (Microsoft, 2024a)
        private readonly EventRepository _repository;
        private readonly RecommendationService _recommendationService;

        public EventsController(EventRepository repository, RecommendationService recommendationService)
        {
            _repository = repository;
            _recommendationService = recommendationService;
        }

        public IActionResult Index(string category, DateTime? date, string sort = "date", string search = "")
        {
            var allEvents = _repository.GetAll();
            var filteredEvents = allEvents.AsEnumerable();

            // (Kumar and Bhatia, 2020)
            if (!string.IsNullOrEmpty(category))
            {
                filteredEvents = filteredEvents.Where(e =>
                    e.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

                _recommendationService.TrackInteraction(category);
                _repository.TrackSearch(category);
            }

            if (date.HasValue)
                filteredEvents = filteredEvents.Where(e => e.Date.Date == date.Value.Date);

            if (!string.IsNullOrEmpty(search))
            {
                filteredEvents = filteredEvents.Where(e =>
                    e.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    e.Description.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    e.Category.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    e.Date.ToString("yyyy-MM-dd").Contains(search));

                // (Kumar and Bhatia, 2020)
                foreach (var matchCat in filteredEvents.Select(e => e.Category).Distinct())
                {
                    _recommendationService.TrackInteraction(matchCat);
                    _repository.TrackSearch(matchCat);
                }
            }

            // (Microsoft, 2024b)
            filteredEvents = sort switch
            {
                "name" => filteredEvents.OrderBy(e => e.Title),
                "category" => filteredEvents.OrderBy(e => e.Category),
                _ => filteredEvents.OrderBy(e => e.Date)
            };

            // (Kumar and Bhatia, 2020)
            var personalized = _recommendationService.GetPersonalizedEvents(filteredEvents);

            var recommendedEvents = _recommendationService
                .GetPersonalizedEvents(allEvents)
                .Where(e => !filteredEvents.Contains(e))
                .Take(3);

            ViewBag.RecommendedEvents = recommendedEvents;
            ViewBag.Search = search;
            ViewBag.Categories = _repository.GetCategories();
            ViewBag.SelectedCategory = category;
            ViewBag.SelectedDate = date;
            ViewBag.Sort = sort;

            //(Microsoft, 2024c)
            ViewBag.RecentlyViewed = _repository.GetRecentlyViewed();

            return View(personalized);
        }

        public IActionResult Details(int id)
        {
            var e = _repository.GetEventById(id);
            if (e == null) return NotFound();

            _repository.AddToRecentlyViewed(e);
            _recommendationService.TrackInteraction(e.Category);
            _repository.TrackSearch(e.Category);

            return View(e);
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                _repository.AddEvent(newEvent);

                _recommendationService.TrackInteraction(newEvent.Category);
                _repository.TrackSearch(newEvent.Category);

                return RedirectToAction("Index");
            }

            return View(newEvent);
        }
    }
}












