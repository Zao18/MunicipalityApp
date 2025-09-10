using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Data;
using MunicipalityApp.Models;

namespace MunicipalityApp.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IssueQueue _queue;

        public IssuesController(IWebHostEnvironment env, IssueQueue queue)
        {
            _env = env;
            _queue = queue;
        }

        [HttpGet]
        public IActionResult Report()
        {
            return View(new Issue());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Report(Issue issue, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                return View(issue);
            }

            try
            {
                if (file != null && file.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var savePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    issue.FilePath = "/uploads/" + uniqueFileName;
                }

                issue.Status = "Submitted";
                _queue.Enqueue(issue);

                TempData["Success"] = "Your issue has been submitted successfully!";
                TempData["Reference"] = issue.ReferenceNumber;

                return RedirectToAction(nameof(Report));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error submitting the issue: " + ex.Message;
                return View(issue);
            }
        }

        public IActionResult Index()
        {
            var issues = _queue.GetAll();
            return View(issues);
        }

    }
}






