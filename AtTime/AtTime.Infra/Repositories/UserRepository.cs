using AtTime.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtTime.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IEnumerable<User> _users;

        public UserRepository()
        {
            _users = new List<User> { new User { Id = 1, Email = "user@user", FullName = "Paul McCartney", Password = "123456" } };
        }

        public Task<User> Get(string email, string password)
        {
            var result = _users.Where(x => x.Email.ToLower() == email.ToLower() && x.Password == password).FirstOrDefault();
            return Task.FromResult(result);
        }
        
        public Task<User> GetByName(string name)
        {
            var result = _users.Where(x => x.FullName.ToLower() == name.ToLower()).FirstOrDefault();
            return Task.FromResult(result);
        }
    }
}
