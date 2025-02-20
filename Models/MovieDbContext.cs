using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    // DbContext class for the Movie database
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        // DbSet property for accessing the tables in the database (need to be names same as table)
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
