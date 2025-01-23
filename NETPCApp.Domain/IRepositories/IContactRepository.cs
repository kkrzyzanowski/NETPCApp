using NETPCApp.Domain.Models;

namespace NETPCApp.Domain.IRepositories
{
    public interface IContactRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
    }
}
