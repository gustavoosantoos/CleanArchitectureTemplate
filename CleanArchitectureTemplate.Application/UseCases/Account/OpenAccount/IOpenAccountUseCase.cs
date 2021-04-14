using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.UseCases.Account.OpenAccount
{
    public interface IOpenAccountUseCase
    {
        Task ExecuteAsync(OpenAccountInput input);
    }
}
