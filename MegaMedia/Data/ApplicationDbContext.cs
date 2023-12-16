using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaMedia.Models;


namespace MegaMedia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<VideoGame> VideoGames { get; set; }

        public DbSet<Movie> Movies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your SQLite connection here
            optionsBuilder.UseSqlite("Filename=multimediamotion.db");
        }

        
    }
}