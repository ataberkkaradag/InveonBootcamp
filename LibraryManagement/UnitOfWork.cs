
using LibraryManagement.Infrastructure;

namespace LibraryManagement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBookRepository Books { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
        }
        

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();   
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
