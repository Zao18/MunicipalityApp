🏛 Municipality App: Local Events & Citizen Engagement

🌟 Project Summary

The Municipality App is an ASP.NET Core MVC (C#) application focused on efficient citizen engagement and local information access.

The core of the project is a high-performance system for managing local events and announcements. It achieves superior speed and responsiveness by leveraging advanced C# data structures for all search, sorting, and personalization features.

✨ Core Features

Events List: Displays all local events with robust search, filtering, and sorting options.

Personalized Recommendations: Uses a Content-Based Algorithm to suggest events based on tracked user interest.

Recently Viewed: Tracks the last events a user viewed for quick access (implemented with a Stack).

Issue Reporting: Placeholder feature for citizens to report municipal issues.

🛠 Technical Implementation & Data Structures

This project is built around specialized C# generic collections for optimal performance:

Feature/Task

Data Structure Used

Purpose & Benefit

Primary Event Storage

SortedDictionary<DateTime, List<Event>>

Maintains events in automatic chronological order for efficient retrieval.

Filtering & Lookup

HashSet<string> (Categories)

Provides O(1) lookup for unique category lists, ensuring fast filter population.

Last Viewed History

Stack<Event>

Implements Last-In, First-Out (LIFO) behavior for accurate history tracking.

Recommendation Engine

Dictionary<string, int> (Interest Scores)

Tracks user interaction frequency to determine personalized priority scores.

Recommendation Algorithm

Content-Based Filtering

Scores and sorts events by user interest frequency before date.

🚀 Getting Started

Prerequisites

.NET 8.0 SDK or newer.

A C# IDE (e.g., Visual Studio or VS Code).

Installation and Run

Clone: git clone [Your-GitHub-Repository-URL]

Navigate: cd MunicipalityApp

Run: dotnet run (Application will typically run on https://localhost:7000/).

💻 Technologies Used

Backend: C#, ASP.NET Core 8.0 MVC

Frontend: HTML5, CSS

Data Management: In-Memory C# Collections

Core Concepts: Dependency Injection, Repository Pattern, LINQ

Reference list

adegeo (2021). Generic Collections in .NET - .NET. [online] Microsoft.com. Available at: https://learn.microsoft.com/en-us/dotnet/standard/generics/collections.Datasciencecentral.com. 

(2011). Data Science Central. [online] Available at: https://www.datasciencecentral.com.tdykstra (2024). 

Dependency injection in ASP.NET Core.[online] Microsoft.com. Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection.wibjorn (n.d.).

Microsoft Learn: Build skills that open doors in your career. [online] learn.microsoft.com. Available at: https://learn.microsoft.com.




