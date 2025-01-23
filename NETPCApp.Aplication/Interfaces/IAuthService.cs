using System.Threading.Tasks;

namespace NETPCApp.Application.Interfaces
{
    public interface IAuthService
    {
        string HashPassword(string password);
        Task<string> LoginAsync(string email, string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
