using System.Collections.Generic;
using System.Linq;

namespace CleanArchitectureTemplate.Domain.Base
{
    public class ErrorsCollection : ValueObject
    {
        public IReadOnlyCollection<ValidationError> Errors { get; private set; }

        private ErrorsCollection(IEnumerable<ValidationError> errors)
        {
            Errors = errors?.ToList() ?? new List<ValidationError>();
        }

        public static ErrorsCollection Create(IEnumerable<ValidationError> errors)
        {
            return new ErrorsCollection(errors);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return Errors;
        }
    }
}
