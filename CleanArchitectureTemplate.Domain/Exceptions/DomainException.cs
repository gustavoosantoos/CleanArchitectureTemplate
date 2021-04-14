using CleanArchitectureTemplate.Domain.Base;
using System;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public ErrorsCollection Errors { get; private set; }

        public DomainException(ValidationError error)
        {
            Errors = ErrorsCollection.Create(new List<ValidationError>() { error });
        }

        public DomainException(ErrorsCollection errors)
        {
            Errors = errors;
        }
    }
}
