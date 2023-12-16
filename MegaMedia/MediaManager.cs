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
            return _context.VideoGames;
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

        public async Task AddVideo(string name, decimal price, DateTime releaseDate, string developer)
        {
            var newVideoGame = new VideoGame
            {
                Name = name,
                Price = price,
                ReleaseDate = releaseDate,
                Developer = developer
            };

            _context.VideoGames.Add(newVideoGame);
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

        public async Task<Movie> GetMovieById(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateMovie(int id, string name, decimal price, DateTime releaseDate, string director, string studio)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie != null)
            {
                movie.Name = name;
                movie.Price = price;
                movie.ReleaseDate = releaseDate;
                movie.Director = director;
                movie.Studio = studio;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<VideoGame> GetVideoGameById(int id)
        {
            return await _context.VideoGames.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateVideo(int id, string name, decimal price, DateTime releaseDate, string developer)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);

            if (videoGame != null)
            {
                videoGame.Name = name;
                videoGame.Price = price;
                videoGame.ReleaseDate = releaseDate;
                videoGame.Developer = developer;
               

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteVideoGame(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);

            if (videoGame != null)
            {
                _context.VideoGames.Remove(videoGame);
                await _context.SaveChangesAsync();
            }
        }


        // Other methods for fetching data or managing models...
    }
}