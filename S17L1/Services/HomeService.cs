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

        public async Task<bool> SaveAsync()
        {
            try
            { 
                return await _context.SaveChangesAsync() > 0;
            }
            catch 
            { 
                return false;
            }
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

        public async Task<Book> GetBookDetailsAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null) 
            { 
                return null;
            }

            return book;
        }

        public async Task<bool> AddBookAsync(AddBookViewModel addBookViewModel)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = addBookViewModel.Title,
                Author = addBookViewModel.Author,
                Genre = addBookViewModel.Genre,
                IsAvailable = addBookViewModel.IsAvailable,
                URL_Image = addBookViewModel.URL_Image
            };

            _context.Books.Add(book);

            return await SaveAsync();
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);

            return await SaveAsync();
        }

        public async Task<bool> UpdateBookAsync(EditBookViewModel editBookViewModel)
        {
            var book = await _context.Books.FindAsync(editBookViewModel.Id);

            if (book == null)
            {
                return false;
            }

            book.Title = editBookViewModel.Title;
            book.Author = editBookViewModel.Author;
            book.Genre = editBookViewModel.Genre;
            book.IsAvailable = editBookViewModel.IsAvailable;
            book.URL_Image = editBookViewModel.URL_Image;

            return await SaveAsync();
        }
    }
}
