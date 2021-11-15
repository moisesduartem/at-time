using AtTime.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtTime.Infra.Repositories
{
    public interface IPointRepository
    {
        public Task Add(Point point);
        public Task<IEnumerable<Point>> GetByAuthorId(int authorId);
    }
}