using Model;

namespace FantaMauiApp.Data.Interfaces
{
    interface IRepository<T>
    {
        Task<int> DeleteAsync(T item);
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(Guid id);
        Task<int> InsertAsync(T item);
    }
}
