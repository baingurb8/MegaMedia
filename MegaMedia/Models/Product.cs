using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaMedia.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now; // Set default release date to current date

        public virtual Movie Movie { get; set; } // Added relationship to Movie
        public virtual VideoGame VideoGame { get; set; } // Added relationship to VideoGame
    }
}