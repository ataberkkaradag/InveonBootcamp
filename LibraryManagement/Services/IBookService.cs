using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
    }
}
