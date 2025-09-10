# MunicipalityApp

This project is a simple C# ASP.NET Core application that allows citizens to report municipal issues and track them in a queue-like system. The application demonstrates how issues are stored, managed, and retrieved using a custom linked list queue implementation.

---

## Prerequisites

Before running the application, make sure you have:

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/en-us/download) installed
- A code editor such as [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

---

## How to Compile

1. Clone or download the repository to your local machine.
   ```bash
   git clone https://github.com/yourusername/MunicipalityApp.git
Navigate into the project folder:

bash
Copy code
cd MunicipalityApp
Restore dependencies:

bash
Copy code
dotnet restore
Build the project:

bash
Copy code
dotnet build

How to Run

To start the application:

dotnet run


This will launch the app on your local development server. By default, it will run at:

https://localhost:5001
http://localhost:5000


Open the above link in your browser.

How to Use

Reporting Issues: Users can submit new issues. Each issue is automatically assigned a unique ID before being added to the queue.

Viewing All Issues: You can retrieve and view the list of all reported issues in the order they were submitted.

Queue Management: The system ensures thread-safe enqueueing and retrieval of issues.
