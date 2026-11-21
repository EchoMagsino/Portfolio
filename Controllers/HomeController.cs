using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new PortfolioViewModel
        {
            Projects =
            [
                new Project(
                    "01",
                    "Campus Scheduler",
                    "ASP.NET Core MVC · EF Core · SQL Server",
                    "A scheduling platform for students: browse sections, catch timetable conflicts before they happen, and export a clean weekly plan.",
                    ["MVC", "Entity Framework", "SQL Server"],
                    "2026"),
                new Project(
                    "02",
                    "Inventory API",
                    "ASP.NET Core Web API · JWT · Swagger",
                    "A REST API for tracking stock across branches, with role-based access, paging, model validation and readable error responses.",
                    ["Web API", "JWT Auth", "REST"],
                    "2025"),
                new Project(
                    "03",
                    "Records Portal",
                    "Razor Pages · SQL Server · Bootstrap",
                    "A records management portal with fast search, audit-friendly logging and printable reports for day-to-day office work.",
                    ["Razor Pages", "Reporting", "Auth"],
                    "2025")
            ],
            SkillGroups =
            [
                new SkillGroup(
                    "Backend",
                    "Where most of my time goes.",
                    [
                        new Skill("C#", 90),
                        new Skill("ASP.NET Core MVC / API", 85),
                        new Skill("SQL Server", 80),
                        new Skill("Entity Framework Core", 78)
                    ]),
                new SkillGroup(
                    "Frontend",
                    "Clean interfaces that stay out of the way.",
                    [
                        new Skill("HTML & CSS", 88),
                        new Skill("Razor Views", 84),
                        new Skill("JavaScript", 76),
                        new Skill("Responsive design", 82)
                    ]),
                new SkillGroup(
                    "Tooling",
                    "The everyday workflow.",
                    [
                        new Skill("Git & GitHub", 82),
                        new Skill("Visual Studio", 86),
                        new Skill("Postman", 78),
                        new Skill("Azure fundamentals", 65)
                    ])
            ],
            Facts =
            [
                new Fact("Education", "BS Computer Science — 3rd Year"),
                new Fact("Focus", "Full-stack web development"),
                new Fact("Stack", "ASP.NET Core · C# · SQL Server"),
                new Fact("Status", "Open to internships")
            ]
        };

        return View(model);
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
