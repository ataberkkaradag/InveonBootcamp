using LibraryManagement.Infrastructure;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement
{
    public class BookRepository(AppDbContext context) : IBookRepository
    {
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await context.Books.AsNoTracking().OrderBy(b=>b.Title).ToListAsync();
            
        }
    }
}
