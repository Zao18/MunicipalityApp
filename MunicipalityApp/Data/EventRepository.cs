using MunicipalityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalityApp.Data
{
    public class EventRepository
    {
        // (Microsoft, 2024c)
        private readonly SortedDictionary<DateTime, List<Event>> _events = new();

        // (Microsoft, 2024c)
        private readonly HashSet<string> _categories = new();

        // (Microsoft, 2024c)
        private readonly Stack<Event> _recentlyViewed = new();

        // (Microsoft, 2024c)
        private readonly Dictionary<string, int> _searchFrequency = new();
        private int _counter = 0;

        public EventRepository()
        {
            SeedEvents();
        }

        public void AddEvent(Event newEvent)
        {
            newEvent.Id = ++_counter;
            var dateKey = newEvent.Date.Date;

            // (Microsoft, 2024c)
            if (!_events.ContainsKey(dateKey))
                _events[dateKey] = new List<Event>();
            _events[dateKey].Add(newEvent);
            // (Microsoft, 2024c)
            _categories.Add(newEvent.Category);
        }

        public void TrackSearch(string? category)
        {
            if (string.IsNullOrEmpty(category)) return;
            // (Kumar and Bhatia, 2020)
            if (_searchFrequency.ContainsKey(category))
                _searchFrequency[category]++;
            else
                _searchFrequency[category] = 1;
        }

        public IReadOnlyDictionary<string, int> GetSearchFrequency() => _searchFrequency;

        private void SeedEvents()
        {
            var today = DateTime.Today;
            var sampleEvents = new List<Event>
            {
                new Event { Title = "Community Book Fair", Category = "Culture", Date = today.AddDays(1), Description = "Explore books from local authors and publishers." },
                new Event { Title = "Neighborhood Watch Meeting", Category = "Safety", Date = today.AddDays(2), Description = "Discuss local safety initiatives and updates." },
                new Event { Title = "Gardening Workshop", Category = "Environment", Date = today.AddDays(3), Description = "Learn eco-friendly gardening tips and tricks." },
                new Event { Title = "Music in the Square", Category = "Culture", Date = today.AddDays(4), Description = "Live performances by local bands." },
                new Event { Title = "Tech Talk: AI for Communities", Category = "Education", Date = today.AddDays(5), Description = "Learn how AI is impacting local communities." },
                new Event { Title = "Senior Fitness Class", Category = "Health", Date = today.AddDays(6), Description = "Low-impact fitness session for seniors." },
                new Event { Title = "Local Business Expo", Category = "Commerce", Date = today.AddDays(7), Description = "Showcase of local small businesses." },
                new Event { Title = "Fire Safety Drill", Category = "Safety", Date = today.AddDays(8), Description = "Practice fire emergency procedures." },
                new Event { Title = "Eco Film Screening", Category = "Environment", Date = today.AddDays(9), Description = "Documentaries on sustainability." },
                new Event { Title = "Youth Leadership Seminar", Category = "Education", Date = today.AddDays(10), Description = "Empowering youth with leadership skills." },
                new Event { Title = "Artisan Craft Fair", Category = "Culture", Date = today.AddDays(11), Description = "Handmade crafts and art from local artisans." },
new Event { Title = "Public Health Awareness Talk", Category = "Health", Date = today.AddDays(12), Description = "Tips and advice from healthcare professionals." },
new Event { Title = "Community Cycling Event", Category = "Transport", Date = today.AddDays(13), Description = "Group cycling event promoting safe commuting." },
new Event { Title = "Local Theater Night", Category = "Culture", Date = today.AddDays(14), Description = "Performances by local theater groups." },
new Event { Title = "Renewable Energy Workshop", Category = "Utilities", Date = today.AddDays(15), Description = "Learn about solar and wind energy solutions." },
new Event { Title = "Farm-to-Table Cooking Demo", Category = "Commerce", Date = today.AddDays(16), Description = "Learn cooking with fresh local ingredients." },
new Event { Title = "Neighborhood Art Walk", Category = "Culture", Date = today.AddDays(17), Description = "Explore murals and public art installations." },
new Event { Title = "Disaster Preparedness Seminar", Category = "Safety", Date = today.AddDays(18), Description = "Prepare your family for emergencies." },
new Event { Title = "Community Yoga Morning", Category = "Health", Date = today.AddDays(19), Description = "Outdoor yoga session for all ages." },
new Event { Title = "Local History Tour", Category = "Education", Date = today.AddDays(20), Description = "Guided tour of historical landmarks in the area." },
new Event { Title = "Sustainable Fashion Workshop", Category = "Environment", Date = today.AddDays(21), Description = "Learn eco-friendly clothing practices." },
new Event { Title = "Open Mic Night", Category = "Culture", Date = today.AddDays(22), Description = "Showcase your talents or enjoy local performers." },
new Event { Title = "Pet Adoption Drive", Category = "Community", Date = today.AddDays(23), Description = "Adopt or support local animal rescues." },
new Event { Title = "Community Debate Club", Category = "Education", Date = today.AddDays(24), Description = "Join discussions on local and global issues." },
new Event { Title = "Local Farmers’ Cooking Contest", Category = "Commerce", Date = today.AddDays(25), Description = "Cooking with ingredients sourced locally." },
new Event { Title = "Beach Cleanup Drive", Category = "Environment", Date = today.AddDays(26), Description = "Join volunteers to clean local beaches." },
new Event { Title = "Emergency Vehicle Expo", Category = "Safety", Date = today.AddDays(27), Description = "Meet local fire, police, and ambulance teams." },
new Event { Title = "Community Choir Performance", Category = "Culture", Date = today.AddDays(28), Description = "Local choir performs classic and contemporary pieces." },
new Event { Title = "Water Safety Workshop", Category = "Health", Date = today.AddDays(29), Description = "Learn how to stay safe around water." },
new Event { Title = "Neighborhood Plant Swap", Category = "Environment", Date = today.AddDays(30), Description = "Exchange plants and gardening tips." },
            };

            foreach (var e in sampleEvents)
            {
                AddEvent(e);
            }
        }

        public IEnumerable<Event> GetAll() => _events.OrderBy(k => k.Key).SelectMany(kvp => kvp.Value).OrderBy(e => e.Date).ThenBy(e => e.Title);

        public Event? GetEventById(int id) => GetAll().FirstOrDefault(e => e.Id == id);

        public void AddToRecentlyViewed(Event e)
        {
            if (e == null) return;
            if (_recentlyViewed.Count == 0 || _recentlyViewed.Peek().Id != e.Id)
            {
                _recentlyViewed.Push(e); // (Microsoft, 2024c)
                if (_recentlyViewed.Count > 10) _recentlyViewed.Pop();
            }
        }

        public IEnumerable<Event> GetRecentlyViewed() => _recentlyViewed.ToList();

        public IEnumerable<string> GetCategories() => _categories.OrderBy(c => c);
    }
}







