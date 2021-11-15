using AtTime.Core.Models;
using System.Threading.Tasks;

namespace AtTime.Infra.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetByName(string name);
        public Task<User> GetByEmail(string email);
    }
}
