using Microsoft.EntityFrameworkCore;

namespace Mission06_Kim.Models
{
    public class MovieContext : DbContext // Database context for handling Movie and Category tables
    {
        // Constructor: Initializes the database context with configuration options
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        // DbSet representing the Movies table in the database
        public DbSet<Movie> Movies { get; set; }

        // DbSet representing the Categories table in the database
        public DbSet<Category> Categories { get; set; }

        // Configures entity relationships and constraints within the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>() // Defines the relationship between Movies and Categories
                .HasOne(m => m.Category) // A movie belongs to one category
                .WithMany(c => c.Movies) // A category can have multiple movies
                .HasForeignKey(m => m.CategoryId); // Foreign key linking movies to categories
        }
    }
}
