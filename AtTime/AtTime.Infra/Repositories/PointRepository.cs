using AtTime.Core.Models;
using System.Collections.Generic;

namespace AtTime.Infra.Repositories
{
    public class PointRepository : IPointRepository
    {
        private readonly IEnumerable<User> _users;

        public PointRepository()
        {
        }
    }
}
