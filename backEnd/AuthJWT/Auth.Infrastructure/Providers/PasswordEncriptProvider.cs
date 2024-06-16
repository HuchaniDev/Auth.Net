using Auth.Application.Providers;
using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Providers;

public class PasswordEncriptProvider:IPaswordEncriptProvider
{
    private readonly PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
    public Task<string> PaswordEncript(string password)
    {
        var passwordHasher = new PasswordHasher<string>();
        string userId = "user123";

        string hashedPassword = passwordHasher.HashPassword(userId, password);

        return Task.FromResult<string>(hashedPassword);
    }

    public Task<bool> VerifyPassword(string hashedPassword, string password)
    {
        string userId = "user123";
        var verificar = passwordHasher.VerifyHashedPassword(userId, hashedPassword, password);
        
        return  Task.FromResult((verificar == PasswordVerificationResult.Success? true : false));
    }
}