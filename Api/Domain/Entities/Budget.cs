using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Budget : Entity
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public decimal Amount { get; set; }

        public ICollection<Expense> Expenses { get; set; } = [];
    }
}
