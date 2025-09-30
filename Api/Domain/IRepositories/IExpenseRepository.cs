using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IExpenseRepository : IRepository<Expense, Guid>
    {
    }
}
