using Application.Dtos;
using Application.IAppServices;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;

namespace Infrastructure.Application.AppServices
{
    public class ExpenseAppService : AppService<ExpenseDto, Expense, Guid>, IExpenseAppService
    {
        public ExpenseAppService(IExpenseRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
