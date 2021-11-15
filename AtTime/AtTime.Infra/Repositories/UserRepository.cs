using AtTime.Core.Models;
using AtTime.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AtTime.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.AsNoTracking()
                                       .Where(x => x.Email.ToLower() == email.ToLower())
                                       .FirstOrDefaultAsync();
        }
        
        public async Task<User> GetByName(string name)
        {
            return await _context.Users.AsNoTracking().Where(x => x.FullName.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        }
    }
}
