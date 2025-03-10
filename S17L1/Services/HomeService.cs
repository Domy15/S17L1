using Microsoft.EntityFrameworkCore;
using S17L1.Data;
using S17L1.Models;
using S17L1.ViewModels;

namespace S17L1.Services
{
    public class HomeService
    {
        private readonly BooksDbContext _context;

        public HomeService(BooksDbContext context)
        {
            _context = context;
        }

        public async Task<BooksListViewModel> GetAllBooks()
        {
            try
            {
                var BooksList = new BooksListViewModel();

                BooksList.Books = await _context.Books.ToListAsync();

                return BooksList;
            }
            catch
            {
                return new BooksListViewModel() { Books = new List<Book>() };
            }
        }
    }
}
