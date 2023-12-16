using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaMedia.Models
{
    public class Movie : Product
    {
        public string Studio { get; set; }

        public string Director { get; set; }


        // Establishing the many-to-many relationship with User
        public virtual ICollection<User> UsersWhoRentedMovies { get; set; } = new List<User>();
    }
}