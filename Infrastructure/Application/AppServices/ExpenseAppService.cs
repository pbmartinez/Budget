using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;

namespace Infrastructure.Application.AppServices
{
    public class ExpenseAppService : AppService<ExpenseDto, Expense, Guid>
    {
        public ExpenseAppService(IRepository<Expense, Guid> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
