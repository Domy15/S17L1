using Microsoft.AspNetCore.Mvc;
using S17L1.Services;
using S17L1.ViewModels;

namespace S17L1.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;

        public HomeController(HomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index() 
        { 
            var BooksList = await _homeService.GetAllBooks();

            return View(BooksList);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var book = await _homeService.GetBookDetailsAsync(id);

            if (book == null) 
            {
                TempData["Error"] = "Error while finding entity on database";
                return RedirectToAction("Index");
            }

            DetailsViewModel bookViewModel = new DetailsViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                IdGenre = book.IdGenre,
                IsAvailable = book.IsAvailable,
                URL_Image = book.URL_Image,
                Genre = book.Genre,
            };

            return View(bookViewModel);
        }

        public async Task<IActionResult> Add()
        {

            AddBookViewModel addBookViewModel = new AddBookViewModel()
            {
                Genres = await _homeService.GetAllGenres()
            };

            return View(addBookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel addBookViewModel)
        {
            ModelState.Remove("Genres");

            if (!ModelState.IsValid) 
            {
                TempData["Error"] = "Error while saving entity to database";
                return RedirectToAction("Add");
            }

            var result = await _homeService.AddBookAsync(addBookViewModel);

            if (!result) 
            {
                TempData["Error"] = "Error while saving entity to database";
                return RedirectToAction("Add");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _homeService.DeleteBookAsync(id);

            if(!result)
            {
                TempData["Error"] = "Error while deleting entity from database";
                return RedirectToAction("Details");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var book = await _homeService.GetBookDetailsAsync(id);
            var genres = await _homeService.GetAllGenres();

            if (book == null)
            {
                return RedirectToAction("Index");
            }

            EditBookViewModel editBook = new EditBookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                IdGenre = book.IdGenre,
                IsAvailable = book.IsAvailable,
                URL_Image = book.URL_Image,
                Genres = genres
            };

            return View(editBook);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel editBookViewModel)
        {
            var result = await _homeService.UpdateBookAsync(editBookViewModel);

            if (!result)
            {
                TempData["Error"] = "Error while updating entity on database";
                return RedirectToAction("Edit");
            }

            return RedirectToAction("Index");
        }
    }
}
