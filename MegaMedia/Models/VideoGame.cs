using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaMedia.Models
{
    public class VideoGame : Product
    {
        public string Developer { get; set; }

        // Establishing the many-to-many relationship with User
        public virtual ICollection<User> UsersWhoRentedGames { get; set; } = new List<User>();
    }
}
