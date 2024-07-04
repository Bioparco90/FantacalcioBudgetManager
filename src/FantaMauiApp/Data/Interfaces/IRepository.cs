using Model;

namespace FantaMauiApp.Data.Interfaces
{
    interface IRepository<T>
    {
        Task<int> DeleteAsync(T item);
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(T item);
        Task<int> InsertAsync(T item);
    }
}
