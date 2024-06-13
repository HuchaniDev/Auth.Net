namespace Auth.Application.Providers;

public interface IPaswordEncriptProvider:IProvider
{
    Task<string> PaswordEncript(string password);

    Task<bool> VerifyPassword(string hashedPassword, string password);
}