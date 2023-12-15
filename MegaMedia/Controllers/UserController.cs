using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MegaMedia.Controllers
{
    public class UserController : Controller
{
    private readonly MediaManager _mediaManager;

    public UserController(MediaManager mediaManager)
    {
        _mediaManager = mediaManager;
    }

    public IActionResult Index()
    {
        // Retrieve all users and display in a view
        var users = _mediaManager.GetAllUsers();
        return View(users);
    }

    public async Task<IActionResult> RentMovie(int userId, int movieId)
    {
        // Rent a movie to a user
        await _mediaManager.RentMovieToUser(userId, movieId);
        return RedirectToAction("Index"); // Redirect back to the user list
    }

    // Other actions: Add, Update, Delete users, etc.
}
}