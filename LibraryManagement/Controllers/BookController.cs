using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class BookController(IBookService bookService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var books=await bookService.GetAllBooksAsync();
            return View(books);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

    }
}
