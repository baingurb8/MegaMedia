using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaMedia.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; }
        public List<VideoGame> RentedGames { get; set; } = new List<VideoGame>(); // User's rented video games
        
        public List<Movie> RentedMovies { get; set; } = new List<Movie>(); // User's rented video games

        
    }
}