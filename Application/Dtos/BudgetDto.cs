using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class BudgetDto : DtoBase
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public decimal Amount { get; set; }

        public ICollection<ExpenseDto> Expenses { get; set; } = [];
    }
}
