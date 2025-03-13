using Microsoft.EntityFrameworkCore;
using S17L1.Models;

namespace S17L1.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Borrow> Borrows { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(b => b.Genre).WithMany(g => g.Books).HasForeignKey(b => b.IdGenre).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Borrow>().Property(b => b.BorrowDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
