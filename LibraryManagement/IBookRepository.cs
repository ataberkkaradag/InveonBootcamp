using LibraryManagement.Models;

namespace LibraryManagement
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
    }
}
