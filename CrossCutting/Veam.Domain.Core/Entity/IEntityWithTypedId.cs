namespace Veam.Domain.Core.Entity
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
