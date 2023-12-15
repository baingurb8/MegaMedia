using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaMedia.Models
{
    public class Movie : Product
    {
        public string Director { get; set; }
        public string Studio { get; set; }

        // Establishing the many-to-many relationship with User
        public virtual ICollection<User> UsersWhoRented { get; set; } = new List<User>();
    }
}