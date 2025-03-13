using Microsoft.EntityFrameworkCore;
using S17L1.Controllers;
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

        public async Task<List<Genre>> GetAllGenres()
        {
            try
            {
                return await _context.Genres.ToListAsync();
            }
            catch
            {
                return new List<Genre>();
            }
        }

        public async Task<BooksListViewModel> GetAllBooks()
        {
            try
            {
                var BooksList = new BooksListViewModel();

                BooksList.Books = await _context.Books.Include(b => b.Genre).ToListAsync();

                return BooksList;
            }
            catch
            {
                return new BooksListViewModel() { Books = new List<Book>() };
            }
        }

        public async Task<Book> GetBookDetailsAsync(Guid id)
        {
            var book = await _context.Books.Include(b => b.Genre).Where(b => b.Id == id).SingleAsync();

            if (book == null) 
            { 
                return null;
            }

            return book;
        }

        public async Task<bool> AddBookAsync(AddBookViewModel addBookViewModel)
        {
            string webPath = null;

            if (addBookViewModel.URL_Image != null)
            {
                var fileName = addBookViewModel.URL_Image.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "images", fileName);

                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await addBookViewModel.URL_Image.CopyToAsync(stream);
                }

                webPath = "/uploads/images/" + fileName;
            }
            
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = addBookViewModel.Title,
                Author = addBookViewModel.Author,
                IdGenre = addBookViewModel.IdGenre,
                IsAvailable = addBookViewModel.IsAvailable,
                URL_Image = webPath
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

            if (editBookViewModel.New_URL_Image != null)
            {
                if (!string.IsNullOrEmpty(book.URL_Image))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", book.URL_Image.TrimStart('/'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                var fileName = editBookViewModel.New_URL_Image.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "images", fileName);

                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await editBookViewModel.New_URL_Image.CopyToAsync(stream);
                }

                book.URL_Image = "/uploads/images/" + fileName;
            }

            book.Title = editBookViewModel.Title;
            book.Author = editBookViewModel.Author;
            book.IdGenre = editBookViewModel.IdGenre;
            book.IsAvailable = editBookViewModel.IsAvailable;

            return await SaveAsync();
        }

        public async Task<bool> AddBorrowAsync(BorrowFormViewModel borrowFormViewModel)
        {
            var book = await _context.Books.Where(b => b.Id == borrowFormViewModel.IdBook).FirstOrDefaultAsync();

            if (book == null) 
            { 
                return false;
            }

            var user = await _context.Users.Where(u => u.Email == borrowFormViewModel.Email).FirstOrDefaultAsync();

            if (user == null)
            {
                user = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = borrowFormViewModel.Name,
                    Surname = borrowFormViewModel.Surname,
                    Email = borrowFormViewModel.Email,
                };

                _context.Users.Add(user);
            }

            var borrow = new Borrow()
            {
                Id = user.Id,
                IdBook = borrowFormViewModel.IdBook,
                BorrowEndDate = borrowFormViewModel.BorrowEndDate,
                IsReturned = false
            };

            _context.Borrows.Add(borrow);

            book.IsAvailable = false;

            return await SaveAsync();
        }

        public async Task<List<BorrowsViewModel>> GetAllBorrowsAsync()
        {
            var borrows = await _context.Borrows.Include(b => b.User).Include(b => b.book).ToListAsync();

            if (!borrows.Any())
            {
                return new List<BorrowsViewModel>();
            }
            
            var borrowsList = new List<BorrowsViewModel>();

            foreach(var b in borrows)
            {
                var borrow = new BorrowsViewModel()
                {
                    IdBook = b.IdBook,
                    IdUser = b.Id,
                    Name = b.User.Name,
                    Surname = b.User.Surname,
                    Title = b.book.Title,
                    URL_Image = b.book.URL_Image
                };
                borrowsList.Add(borrow);
            }

            return borrowsList;
        }
    }
}
