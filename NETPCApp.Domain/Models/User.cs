using Microsoft.AspNetCore.Identity;
using NETPCApp.Domain.Models;

namespace NETPCApp.Domain.Models
{
    public class User: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime BirthDate { get; set; }
        public string Category { get; set; }
        public string? Subcategory { get; set; }
    }
}
