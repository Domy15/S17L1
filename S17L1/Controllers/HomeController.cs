using Microsoft.AspNetCore.Mvc;
using S17L1.Services;

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
    }
}
