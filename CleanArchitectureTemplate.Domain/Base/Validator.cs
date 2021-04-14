using FluentValidation;

namespace CleanArchitectureTemplate.Domain.Base
{
    public abstract class Validator<T> : AbstractValidator<T>
    {
        public abstract (bool isValid, ErrorsCollection errors) ValidateObject(T obj);
    }
}
