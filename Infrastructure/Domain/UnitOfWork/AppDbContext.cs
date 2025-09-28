using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.UnitOfWork
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
