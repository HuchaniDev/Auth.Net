namespace Auth.Application.Providers;

public interface IJwTokenProvider
{
    Task<string> GenerateToken(Guid id,string name, string username );
}