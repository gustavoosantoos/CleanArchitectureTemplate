namespace CleanArchitectureTemplate.Domain.Base
{
    public class ValidationError
    {
        public string Code { get; private set; }
        public string Message { get; private set; }
        
        public ValidationError(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
