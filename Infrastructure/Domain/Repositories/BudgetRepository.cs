using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Domain.UnitOfWork;

namespace Infrastructure.Domain.Repositories
{
    public class BudgetRepository : Repository<Budget>, IBudgetRepository
    {
        public BudgetRepository(AppDbContext context) : base(context)
        {
        }
    }
}
