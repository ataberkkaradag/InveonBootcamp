using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public class BookService(IUnitOfWork unitOfWork) : IBookService
    {
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await unitOfWork.Books.GetBooksAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await unitOfWork.Books.GetBookByIdAsync(id);
        }
    }
}
