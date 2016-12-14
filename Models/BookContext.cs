using Microsoft.EntityFrameworkCore;

namespace HealthForge.AspNetDemo.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
