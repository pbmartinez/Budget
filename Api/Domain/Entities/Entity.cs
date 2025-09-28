namespace Domain.Entities
{
    public class Entity : BaseEntity<Guid>
    {
        public override bool IsTransient() => Id == Guid.Empty;

        public override void GenerateIdentity()
        {
            if (IsTransient())
                Id = Guid.NewGuid();
        }
    }
}
