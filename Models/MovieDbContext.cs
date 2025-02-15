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

        // DbSet property for accessing the Movies table in the database
        public DbSet<Movie> Movies { get; set; }
    }
}
