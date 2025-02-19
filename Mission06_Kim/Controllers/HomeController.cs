using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Kim.Models;
using System.Linq;

namespace Mission06_Kim.Controllers
{
    public class HomeController : Controller
    {
        // Injects MovieContext to interact with the database
        private readonly MovieContext _context;

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        // Returns the Index (Home) page
        public IActionResult Index()
        {
            return View();
        }

        // Returns the "Get to Know Joel" page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        //  Handles GET request: Displays the AddMovie form and the list of movies
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Movies = _context.Movies.ToList(); // Fetch all movies from the database
            return View(new Movie()); // Pass an empty Movie object to the form
        }

        // Handles POST request: Saves the submitted movie to the database
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid) // Ensures all required fields are correctly filled
            {
                _context.Movies.Add(movie); // Adds new movie entry to the database
                _context.SaveChanges(); // Commits changes to the database
                return RedirectToAction("Confirmation", new { title = movie.Title }); // Redirects to confirmation page with movie title
            }

            ViewBag.Movies = _context.Movies.ToList(); // Reloads movies if form submission fails
            return View(movie);
        }

        // Handles the Confirmation Page, displaying the submitted movie title
        public IActionResult Confirmation(string title)
        {
            // If the title is null or empty, provide a default message to prevent errors
            ViewBag.MovieTitle = string.IsNullOrEmpty(title) ? "Unknown" : title;

            return View(); // Returns the Confirmation view
        }
    }
}





