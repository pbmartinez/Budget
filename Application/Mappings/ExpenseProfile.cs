using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense,ExpenseDto>()
                .ForMember(g => g.Budget, options => options.MapFrom(f => f.Budget))
                .ReverseMap();
        }
    }
}
