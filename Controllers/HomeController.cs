using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Horror_Reviews.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Horror_Reviews.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<string> movies = new List<string>()
            {
                "Alien",
                "Terror Train",
                "Ju-on: The Grudge",
                "Scream",
                "Halloween",
                "The Fly"
            };

        ViewBag.Movies = new SelectList(movies);

        return View();
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

