using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class BudgetProfile : Profile
    {
        public BudgetProfile()
        {
            CreateMap<Budget, BudgetDto>()
                .ForMember(g => g.Expenses, options => options.MapFrom(f => f.Expenses))
                .ReverseMap();
        }
    }
}
