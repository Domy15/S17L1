using Microsoft.EntityFrameworkCore;
using S17L1.Models;

namespace S17L1.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
