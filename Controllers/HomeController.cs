using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie newMovie)
        {
            // this is how to add a new movie to the database
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            return View("Confirmation");
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
