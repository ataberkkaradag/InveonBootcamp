using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        List<Book> books = new List<Book>
        {
            new Book{Id=1,Title="Homo Deus",Author="Yuval Noah Harari"},
            new Book{Id=1,Title="Sapiens",Author="Yuval Noah Harari"}
        };
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(books);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            return Ok(book);
        }


        [HttpPost]
        public IActionResult Create(Book book)
        {
            books.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);

        }


        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Book updateBook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            book.Title = updateBook.Title;
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            books.Remove(book);
            return NoContent();
        }
    }
}

