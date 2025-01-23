using NETPCApp.Domain.Models;

namespace NETPCApp.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
