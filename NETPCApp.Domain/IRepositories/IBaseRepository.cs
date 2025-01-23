namespace NETPCApp.Domain.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
