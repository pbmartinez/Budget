using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ExpenseDto :DtoBase
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public decimal Amount { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        public Guid BudgetId { get; set; }
        public BudgetDto? Budget { get; set; }
    }
}