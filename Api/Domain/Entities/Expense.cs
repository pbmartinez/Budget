using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Expense : Entity
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public decimal Amount { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        public Guid BudgetId { get; set; }
        public Budget? Budget { get; set; }
    }
}
