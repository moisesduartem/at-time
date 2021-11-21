using AtTime.Core.Models;
using AtTime.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtTime.Infra.Repositories
{
    public class PointRepository : IPointRepository
    {
        private readonly DataContext _context;

        public PointRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Point point)
        {
            _context.Points.Add(point);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Point>> GetFromToday(int userId)
        {
            return await _context.Points.AsNoTracking()
                                        .Where(x => x.AuthorId == userId && x.Time.Date == DateTime.Today)
                                        .OrderByDescending(x => x.Time)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Point>> GetByAuthorId(int authorId)
        {
            return await _context.Points.AsNoTracking()
                                        .Include(x => x.Author)
                                        .Where(x => x.AuthorId == authorId)
                                        .Select(x => 
                                            new Point {
                                                Id = x.Id,
                                                Time = x.Time,
                                                AuthorId = x.AuthorId,
                                                Author = new User
                                                {
                                                    Id = x.AuthorId,
                                                    FullName = x.Author.FullName,
                                                    Email = x.Author.Email,
                                                    Role = x.Author.Role
                                                }
                                            }
                                         )
                                        .ToListAsync();
        }

        public async Task<Point> GetUserLastPoint(int userId)
        {
            return await _context.Points.AsNoTracking()
                                        .Where(x => x.AuthorId == userId)
                                        .OrderByDescending(x => x.Time)
                                        .FirstOrDefaultAsync();
        }
    }
}
