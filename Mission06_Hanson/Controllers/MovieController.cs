using Microsoft.AspNetCore.Mvc;
using Mission06_Hanson.Models;

namespace Mission06_Hanson.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _context;

        public MovieController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return RedirectToAction("Confirmation");
            }

            return View(movie);
        }

        public IActionResult Confirmation()
        {
            return View();
        }

    }
}
