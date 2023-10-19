using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Horror_Reviews.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Horror_Reviews.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository repo;

        public MovieController(IMovieRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var movie = repo.GetAllMovies();

            return View(movie);
        }

        public IActionResult ViewMovie(int id)
        {
            var movie = repo.GetMovie(id);
            return View(movie);
        }

        public IActionResult InsertMovie()
        {
            var movie = repo.AssignMovie();
            return View(movie);
        }

        public IActionResult InsertMovieToDatabase(Movie movieToInsert)
        {
            repo.InsertMovie(movieToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateMovie(int id)
        {
            Movie movie = repo.GetMovie(id);
            if (movie == null)
            {
                return View("MovieNotFound");
            }
            return View(movie);
        }

        public IActionResult UpdateMovieToDatabase(Movie movie)
        {
            repo.UpdateMovie(movie);

            return RedirectToAction("ViewMovie", new { id = movie.MovieID });
        }

        public IActionResult DeleteMovie(Movie movie)
        {
            repo.DeleteMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Search (string searchString)
        {
            var searchResults = repo.SearchMovie(searchString);

            return View(searchResults);
        }

    }
}

