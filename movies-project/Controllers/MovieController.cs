using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movies_project.Data;
using movies_project.Models;

namespace movies_project.Controllers
{
	[Authorize]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var moivesDBContext = _context.Movies.Include(m => m.Genre);
            return View(await moivesDBContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Story,Director,DateShow,Rate,Poster,Runtime,Actor1,Actor2,Actor3,Actor4,GenreId,Trailer")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", movie.GenreId);
            return View(movie);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", movie.GenreId);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Story,Director,DateShow,Rate,Poster,Runtime,Actor1,Actor2,Actor3,Actor4,GenreId,Trailer")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", movie.GenreId);
            return View(movie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'moivesDBContext.Movies'  is null.");
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
