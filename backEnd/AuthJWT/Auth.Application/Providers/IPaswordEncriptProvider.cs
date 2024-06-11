namespace Auth.Application.Providers;

public interface IPaswordEncriptProvider:IProvider
{
    Task<string> PaswordEncript(string password);
}