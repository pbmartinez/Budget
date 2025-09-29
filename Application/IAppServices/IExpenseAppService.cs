using Application.Dtos;

namespace Application.IAppServices
{
    public interface IExpenseAppService : IAppService<ExpenseDto, Guid>
    {
    }
}
