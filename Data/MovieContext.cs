using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts) { }

    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .ToContainer("Movies")
            .HasPartitionKey(m => m.Id);

        modelBuilder.Entity<Movie>()
            .Property(m => m.Id)
            .ToJsonProperty("id");
    }
}