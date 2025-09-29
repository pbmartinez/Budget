using Application.Dtos;

namespace Application.IAppServices
{
    public interface IBudgetAppService : IAppService<BudgetDto, Guid>
    {
    }
}
