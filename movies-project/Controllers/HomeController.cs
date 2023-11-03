using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using movies_project.Data;
using movies_project.Models;
using System.Diagnostics;

namespace movies_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.NewMovies = _context.Movies.OrderByDescending(m=> m.DateShow).Take(5).ToList();
            ViewBag.TopMovies = _context.Movies.OrderByDescending(m => m.Rate).Take(10).ToList();
            ViewBag.Reviews = _context.Reviews.ToList();
            return View(movies);
        }
        public IActionResult Movies(int n)
        { 
            var genres = _context.Genres.ToList();
            ViewBag.Movies = _context.Movies.ToList();
            return View(genres);
        }
        public IActionResult MovieSearch(string searchQuery)
        {
            var movies = _context.Movies.Where(x => x.Name.Contains(searchQuery)).ToList();
            return View("Movie", movies);
        }
        public IActionResult Movie(int id)
        {
            var movies = _context.Movies.Where(x => x.GenreId == id).ToList();
            return View(movies);
        }

        public IActionResult Team()
        {
            var team = _context.Teams.ToList();
            return View(team);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie is null)
            {
                return NotFound();
            }
            ViewBag.movieImages = _context.MovieImages.Where(x => x.MovieId == movie.Id).ToList();

            ViewBag.genre = _context.Genres.FirstOrDefault(x => x.Id == movie.GenreId);

            return View(movie);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult SaveReview(Review model)
        {
            _context.Reviews.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}