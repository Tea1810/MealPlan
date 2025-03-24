using System.Diagnostics;
using MealPlan.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealPlan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Recipe()
        {
            return View();
        }
        public IActionResult CreateEditRecipe()
        {
            return View();
        }
        public IActionResult CreateIngredients()
        {
            return View();
        }
        public IActionResult Journal()
        {
            return View();
        }
        public IActionResult AddMeal()
        {
            return View();
        }
        public IActionResult SeeRecipe()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogInPage()
        {
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
}
