using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Domain.UnitOfWork;

namespace Infrastructure.Domain.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(AppDbContext context) : base(context)
        {
        }
    }
}
