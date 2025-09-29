using Application.Dtos;
using Application.IAppServices;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;

namespace Infrastructure.Application.AppServices
{
    public class BudgetAppService : AppService<BudgetDto, Budget, Guid>, IBudgetAppService
    {
        public BudgetAppService(IBudgetRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
