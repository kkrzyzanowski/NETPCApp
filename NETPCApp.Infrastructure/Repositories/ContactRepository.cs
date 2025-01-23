using Microsoft.EntityFrameworkCore;
using NETPCApp.Domain.IRepositories;
using NETPCApp.Domain.Models;
using NETPCApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETPCApp.Infrastructure.Repositories
{
    public class ContactRepository : BaseRepository<User>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        
    }
}
