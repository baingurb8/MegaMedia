using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MegaMedia.Controllers
{
    public class MovieController : Controller
{
    private readonly MediaManager _mediaManager;

    public MovieController(MediaManager mediaManager)
    {
        _mediaManager = mediaManager;
    }

    public IActionResult Index()
    {
        // Retrieve all movies and display in a view
        var movies = _mediaManager.GetAllMovies();
        return View(movies);
    }

    public async Task<IActionResult> RentMovie(int userId, int movieId)
    {
        // Rent a movie to a user
        await _mediaManager.RentMovieToUser(userId, movieId);
        return RedirectToAction("Index"); // Redirect back to the movie list
    }

    // Other actions: Add, Update, Delete movies, etc.
}
}