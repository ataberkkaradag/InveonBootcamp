namespace LibraryManagement
{
    public interface IUnitOfWork:IDisposable
    {
        IBookRepository Books { get; }

        Task<int> CompleteAsync();
    }
}
