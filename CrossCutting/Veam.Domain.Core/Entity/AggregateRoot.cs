using System;

namespace Veam.Domain.Core.Entity
{
    /// <summary>
    /// Guid Id, Auditable Properties and Equal and GetHashcode methods
    /// </summary>
    public abstract class AggregateRoot : AuditableEntity
    {
       // public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as AggregateRoot;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(AggregateRoot a, AggregateRoot b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(AggregateRoot a, AggregateRoot b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}