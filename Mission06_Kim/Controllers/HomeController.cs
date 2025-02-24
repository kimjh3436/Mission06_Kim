using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Kim.Models;
using System.Linq;

namespace Mission06_Kim.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        // Display all movies with category names
        public IActionResult Index()
        {
            var movies = _context.Movies
                .Include(m => m.Category)  // ✅ Join with Categories table
                .ToList();
            return View(movies);
        }

        // Get to Know Joel Page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }


        // Load MovieCollection form
        public IActionResult MovieCollection()
        {
            var movies = _context.Movies.Include(m => m.Category).ToList();

            var viewModel = new MovieViewModel
            {
                Movie = new Movie(),  // New movie form
                Movies = movies       // List of existing movies
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            var movies = _context.Movies.Include(m => m.Category).ToList();

            var viewModel = new MovieViewModel
            {
                Movie = new Movie(),  // New movie form
                Movies = movies       // List of existing movies
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddMovie(MovieViewModel viewModel)
        {
            if (ModelState.IsValid) // ✅ Ensure form validation
            {
                _context.Movies.Add(viewModel.Movie);
                _context.SaveChanges();
                return RedirectToAction("AddMovie"); // ✅ Redirect after adding
            }

            // Reload movies to pass to the view
            viewModel.Movies = _context.Movies.Include(m => m.Category).ToList();
            return View(viewModel);
        }

    }
}








