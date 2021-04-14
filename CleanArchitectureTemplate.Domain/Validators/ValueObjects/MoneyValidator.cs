using CleanArchitectureTemplate.Domain.Base;
using CleanArchitectureTemplate.Domain.ValueObjects;
using FluentValidation;
using System.Data;
using System.Linq;

namespace CleanArchitectureTemplate.Domain.Validators.ValueObjects
{
    public class MoneyValidator : Validator<Money>
    {
        public MoneyValidator()
        {
            RuleFor(m => m.Amount)
                .GreaterThan(0)
                .WithErrorCode("money.amount")
                .WithMessage("Amount must be greater than zero");
        }

        public override (bool isValid, ErrorsCollection errors) ValidateObject(Money money)
        {
            var result = Validate(money);
            var errors = result.Errors.Select(e => new ValidationError(e.ErrorCode, e.ErrorMessage));
            return (result.IsValid, ErrorsCollection.Create(errors));
        }
    }
}
