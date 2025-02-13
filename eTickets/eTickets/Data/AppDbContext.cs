using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(a => new
            {
                a.ActorId,
                a.MovieId,
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Movie).WithMany(a => a.Actors_Movies).
                HasForeignKey(a => a.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Actor).WithMany(a => a.Actors_Movies).
                HasForeignKey(a => a.ActorId);
                base.OnModelCreating(modelBuilder);
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
