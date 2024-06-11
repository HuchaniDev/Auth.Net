using Auth.Domain.Adapters;
using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Providers;

public class PasswordEncriptAdapter: IPasswordEncriptAdapter
{
    public string PasswordEncript(string password)
    {
        var passwordHasher = new PasswordHasher<string>();
        string userId = "user123";

        string hashedPassword = passwordHasher.HashPassword(userId, password);

        return hashedPassword;
    }
}