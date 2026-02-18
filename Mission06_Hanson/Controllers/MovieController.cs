using Microsoft.AspNetCore.Mvc;
using Mission06_Hanson.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                })
                .ToList();

            return View(new Movie());
        }

        [HttpPost]
        public IActionResult EnterMovie(Movie movie)
        {
            // Rebuild categories if the form has validation errors and we need to re-render the view
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                })
                .ToList();

            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return RedirectToAction("Confirmation", new { title = movie.Title });
            }

            return View(movie);
        }

        public IActionResult Confirmation(string title)
        {
            ViewBag.MovieTitle = title;
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title.ToLower())
                .ToList();

            return View(movies);
        }

        // GET: /Movie/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound();

            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                })
                .ToList();

            return View(movie);
        }

        // POST: /Movie/Edit/5
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                })
                .ToList();

            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            _context.Movies.Update(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: /Movie/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Category)
                .FirstOrDefault(m => m.MovieId == id);

            if (movie == null) return NotFound();

            return View(movie);
        }
    }
}
