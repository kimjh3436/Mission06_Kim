using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Kim.Models;

namespace Mission06_Kim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieContext _context;

        // Constructor: Initializes database context and logger
        public HomeController(MovieContext initialDB, ILogger<HomeController> logger)
        {
            _context = initialDB;
            _logger = logger;
        }

        // Displays the home page
        public IActionResult Index()
        {
            return View();
        }

        // Displays the "Get to Know Joel" page with links to additional resources
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // Loads the form to add a new movie to the collection
        public IActionResult Add()
        {
            ViewBag.Categories = _context.Categories.ToList(); // Populate categories dropdown
            return View(new Movie()); // Returns a new Movie object for the form
        }

        // Displays confirmation page after successfully adding a movie
        public IActionResult Confirmation(Movie movie)
        {
            return View(movie); // Shows the details of the newly added movie
        }

        [HttpPost]
        // Handles form submission for adding a new movie
        public IActionResult Add(Movie response)
        {
            if (ModelState.IsValid) // Validate the movie data before adding
            {
                _context.Movies.Add(response); // Save movie to the database
                _context.SaveChanges(); // Commit the changes
                return View("Confirmation", response); // Redirect to confirmation page
            }
            else // If validation fails, return the form with errors
            {
                ViewBag.Categories = _context.Categories.ToList(); // Reload categories dropdown
                return View(response); // Display the form again with validation errors
            }
        }

        // Displays a list of all movies in the collection
        public IActionResult MovieCollection()
        {
            var movies = _context.Movies
                .Include(m => m.Category) // Load category data for each movie
                .ToList(); // Retrieve all movies from the database
            return View(movies);
        }

        [HttpGet]
        // Retrieves movie details for editing based on movie ID
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies.Single(x => x.MovieId == id); // Fetch specific movie
            ViewBag.Categories = _context.Categories.ToList(); // Populate category dropdown
            return View("Add", recordToEdit); // Load the Add view with existing movie data
        }

        [HttpPost]
        // Updates an existing movie in the database
        public IActionResult Edit(Movie updatedMovie)
        {
            _context.Update(updatedMovie); // Apply changes to the movie
            _context.SaveChanges(); // Save changes in database
            return RedirectToAction("MovieCollection"); // Redirect back to the movie list
        }

        [HttpGet]
        // Retrieves movie details for deletion confirmation
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies.Single(x => x.MovieId == id); // Fetch the movie
            return View(recordToDelete); // Show confirmation page with movie details
        }

        [HttpPost]
        // Deletes the specified movie from the database
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie); // Remove movie from database
            _context.SaveChanges(); // Commit the deletion
            return RedirectToAction("MovieCollection"); // Redirect to updated movie list
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // Handles application errors and displays the error page
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}








