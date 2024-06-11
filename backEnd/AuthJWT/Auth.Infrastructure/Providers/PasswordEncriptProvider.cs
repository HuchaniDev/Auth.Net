using Auth.Application.Providers;
using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Providers;

public class PasswordEncriptProvider:IPaswordEncriptProvider
{
    public Task<string> PaswordEncript(string password)
    {
        var passwordHasher = new PasswordHasher<string>();
        string userId = "user123";

        string hashedPassword = passwordHasher.HashPassword(userId, password);

        return Task.FromResult<string>(hashedPassword);
    }
    
}