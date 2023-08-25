namespace Application.Handlers.GenerateTokenHandler;

public interface IGenerateTokenHandler
{
    Task<string> HandleAsync(GenerateTokenHandlerRequest request);
}