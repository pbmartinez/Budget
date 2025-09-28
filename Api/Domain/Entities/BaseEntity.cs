using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public abstract class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public abstract bool IsTransient();

        public abstract void GenerateIdentity();
    }
}
