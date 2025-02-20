using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        // db connection variable
        private readonly MovieDbContext _context;
        // db connection constructor
        public HomeController(MovieDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMovie()
        {

            // add categories to the view bag
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            // pass in a blank move (with the next Id)
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult AddMovie(Movie newMovie)
        {
            if (ModelState.IsValid)// error handling
            {
                // this is how to add a new movie to the database
                _context.Movies.Add(newMovie);
                _context.SaveChanges();
                return View("Confirmation");
            }
            else
            {   // pass back the invalid movie data they sent us
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName).ToList();
                return View(newMovie);
            }
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            // find the movie that matches the id
            var movieToEdit = _context.Movies
                .Single(x => x.MovieId == id);
            // add categories to the view bag
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            // populate the AddMovie view with the movie to edit
            return View("AddMovie", movieToEdit);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            // post the movie to the db which will update based on MovieId
            _context.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("SeeCollection");
        }

        public IActionResult DeleteMovie(int id)
        {
            // get the movie that matches the id and delete it
            var movie = _context.Movies.Single(x => x.MovieId == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            // re query the movie collection to display the movies (minus the deleted one)
            return RedirectToAction("SeeCollection");
        }


        public IActionResult SeeCollection()
        {
            var collection = _context.Movies
                .OrderByDescending(x => x.MovieId).ToList();
            return View(collection);
        }
    }
}
