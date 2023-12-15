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
        public DbSet<Movie> Movies { get; set; }
        public DbSet<VideoGame> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your SQLite connection here
            optionsBuilder.UseSqlite("Filename=multimediamotion.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary keys
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Movie>().HasKey(m => m.Id);
            modelBuilder.Entity<VideoGame>().HasKey(g => g.Id);

            // Define relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.RentedMovies)
                .WithMany(m => m.UsersWhoRented)
                .UsingEntity(j => j.ToTable("UserRentedMovies"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.RentedGames)
                .WithMany(g => g.UsersWhoRented)
                .UsingEntity(j => j.ToTable("UserRentedGames"));

            base.OnModelCreating(modelBuilder);
        }
    }
}