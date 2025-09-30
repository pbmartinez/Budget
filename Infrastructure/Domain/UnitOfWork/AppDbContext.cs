using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.UnitOfWork
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}
