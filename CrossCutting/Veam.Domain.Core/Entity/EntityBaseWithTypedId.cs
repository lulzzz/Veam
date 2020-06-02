namespace Veam.Domain.Core.Entity
{
    public abstract class EntityBaseWithTypedId<TId> :  IEntityWithTypedId<TId>
    {
        public virtual TId Id { get;  set; }
      
    }

}
