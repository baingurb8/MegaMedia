using MegaMedia.Data;
using MegaMedia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MegaMedia
{
    public class MediaManager
    {
        private readonly ApplicationDbContext _context;

        public MediaManager()
        {
            _context = new ApplicationDbContext();
        }

        public IQueryable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return _context.Movies;
        }

        public IQueryable<VideoGame> GetAllVideoGames()
        {
            return _context.Games;
        }

        public async Task AddUser(string name, string email, string password, bool isAdmin)
        {
            var newUser = new User
            {
                Name = name,
                Email = email,
                PasswordHash = password, // You should hash the password for security
                IsAdmin = isAdmin
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task AddMovie(string name, decimal price, DateTime releaseDate, string director, string studio)
        {
            var newMovie = new Movie
            {
                Name = name,
                Price = price,
                ReleaseDate = releaseDate,
                Director = director,
                Studio = studio
            };

            _context.Movies.Add(newMovie);
            await _context.SaveChangesAsync();
        }

        public async Task AddVideoGame(string name, decimal price, DateTime releaseDate, string developer)
        {
            var newGame = new VideoGame
            {
                Name = name,
                Price = price,
                ReleaseDate = releaseDate,
                Developer = developer
            };

            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
        }

        public async Task RentMovieToUser(int userId, int movieId)
        {
            var user = await _context.Users.Include(u => u.RentedMovies).FirstOrDefaultAsync(u => u.Id == userId);
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if (user != null && movie != null)
            {
                user.RentedMovies.Add(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RentVideoGameToUser(int userId, int gameId)
        {
            var user = await _context.Users.Include(u => u.RentedGames).FirstOrDefaultAsync(u => u.Id == userId);
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId);

            if (user != null && game != null)
            {
                user.RentedGames.Add(game);
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<Movie> GetRentedMoviesForUser(int userId)
        {
            return _context.Users.Include(u => u.RentedMovies).Where(u => u.Id == userId).SelectMany(u => u.RentedMovies);
        }

        public IQueryable<VideoGame> GetRentedGamesForUser(int userId)
        {
            return _context.Users.Include(u => u.RentedGames).Where(u => u.Id == userId).SelectMany(u => u.RentedGames);
        }

        // Other methods for fetching data or managing models...
    }
}
