using AtTime.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AtTime.Infra.Database
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
    }
}
