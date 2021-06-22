using Microsoft.EntityFrameworkCore;
using System;
using VideoApp.Models;

namespace VideoApp.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = 1, Name = "Action" },
                new Genre() { GenreId = 2, Name = "Comedy" },
                new Genre() { GenreId = 3, Name = "Sci-Fi" },
                new Genre() { GenreId = 4, Name = "Horror" }
                );

            modelBuilder.Entity<Actor>().HasData(
                new Actor() { ActorId = 1, FirstName = "Bruce", LastName = "Willis", DayOfBirth = new DateTime(1955, 3, 19) },
                new Actor() { ActorId = 2, FirstName = "Johny", LastName = "Depp", DayOfBirth = new DateTime(1963, 6, 9) },
                new Actor() { ActorId = 3, FirstName = "Bernie", LastName = "Mac", DayOfBirth = new DateTime(1957, 10, 5) },
                new Actor() { ActorId = 4, FirstName = "Kevin", LastName = "Hart", DayOfBirth = new DateTime(1979, 7, 6) }
                );

            modelBuilder.Entity<Video>().HasData(
                new Video() { VideoId = 1, Name = "Ride Along", GenreId = 2 },
                new Video() { VideoId = 2, Name = "Oceans 11", GenreId = 1 },
                new Video() { VideoId = 3, Name = "The Sixth Sense", GenreId = 4 },
                new Video() { VideoId = 4, Name = "Transcendence", GenreId = 3 }
                );
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }

    }
}
