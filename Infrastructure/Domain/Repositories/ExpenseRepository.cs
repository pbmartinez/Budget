using Domain.Entities;
using Infrastructure.Domain.UnitOfWork;

namespace Infrastructure.Domain.Repositories
{
    public class ExpenseRepository : Repository<Expense>
    {
        public ExpenseRepository(AppDbContext context) : base(context)
        {
        }
    }
}
