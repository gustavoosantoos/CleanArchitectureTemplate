using CleanArchitectureTemplate.Domain.Base;
using CleanArchitectureTemplate.Domain.Exceptions;
using CleanArchitectureTemplate.Domain.Validators.ValueObjects;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Amount { get; private set; }

        private Money(decimal amount) => Amount = amount;

        public static (bool canCreate, ErrorsCollection errors) CanCreate(decimal amount)
        {
            return new MoneyValidator().ValidateObject(new Money(amount));
        }

        public static Money Create(decimal amount)
        {
            var (canCreate, errors) = CanCreate(amount);

            if (!canCreate)
                throw new DomainException(errors);

            return new Money(amount);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}
