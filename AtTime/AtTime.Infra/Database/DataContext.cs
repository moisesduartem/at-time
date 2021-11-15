using Microsoft.EntityFrameworkCore;

namespace AtTime.Infra.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
    }
}
