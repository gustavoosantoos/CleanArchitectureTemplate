using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitectureTemplate.Domain.Base
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public bool Equals(ValueObject other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (!(obj is ValueObject)) return false;

            return this == (obj as ValueObject);
        }

        public static bool operator ==(ValueObject objectA, ValueObject objectB)
        {
            if (ReferenceEquals(objectA, objectB))
                return true;

            if (objectA is null || objectB is null)
                return false;

            return objectA.GetType() == objectB.GetType() &&
                objectA.GetEqualityComponents().SequenceEqual(objectB.GetEqualityComponents());
        }

        public static bool operator !=(ValueObject objectA, ValueObject objectB)
        {
            return !(objectA == objectB);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;

                foreach (var item in GetEqualityComponents())
                {
                    hash = HashCode.Combine(hash, item) * 31;
                }

                return hash;
            }
        }
    }
}
