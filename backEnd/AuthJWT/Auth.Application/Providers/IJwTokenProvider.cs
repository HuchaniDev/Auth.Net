namespace Auth.Application.Providers;

public interface IJwTokenProvider
{
    Task<string> GenerateToken(string name, string username );
}