using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MegaMedia.Controllers
{
    public class VideoGameController : Controller
{
    private readonly MediaManager _mediaManager;

    public VideoGameController(MediaManager mediaManager)
    {
        _mediaManager = mediaManager;
    }

    public IActionResult Index()
    {
        // Retrieve all video games and display in a view
        var games = _mediaManager.GetAllVideoGames();
        return View(games);
    }

    public async Task<IActionResult> RentGame(int userId, int gameId)
    {
        // Rent a game to a user
        await _mediaManager.RentVideoGameToUser(userId, gameId);
        return RedirectToAction("Index"); // Redirect back to the video game list
    }

    // Other actions: Add, Update, Delete video games, etc.
}
}