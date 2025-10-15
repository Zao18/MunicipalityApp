using MunicipalityApp.Models;
using MunicipalityApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalityApp.Services
{
    public class RecommendationService
    {
        private readonly EventRepository _repository;

        // (Kumar and Bhatia, 2020)
        private readonly Dictionary<string, int> _categoryInterest = new();

        private readonly int _minInteractionsPerCategory = 2;

        // (Microsoft, 2024a)
        public RecommendationService(EventRepository repository)
        {
            _repository = repository;
        }

        public void TrackInteraction(string? category)
        {
            // Kumar and Bhatia, 2020)
            if (string.IsNullOrEmpty(category)) return;

            if (_categoryInterest.ContainsKey(category))
                _categoryInterest[category]++;
            else
                _categoryInterest[category] = 1;
        }

        public IEnumerable<Event> GetPersonalizedEvents(IEnumerable<Event> events)
        {
            // (Kumar and Bhatia, 2020)
            var activeCategories = _categoryInterest
                .Where(kvp => kvp.Value >= _minInteractionsPerCategory)
                .Select(kvp => kvp.Key)
                .ToHashSet();

            if (!activeCategories.Any())
                return events;

            // Kumar and Bhatia, 2020)
            return events
                .OrderByDescending(e => activeCategories.Contains(e.Category) ? _categoryInterest[e.Category] : 0)
                .ThenBy(e => e.Date);
        }

        public void ResetRecommendations() => _categoryInterest.Clear();
    }
}




