
namespace DataAccess.Contracts
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> AllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<string> DeleteAsync(string id);
    }
}
