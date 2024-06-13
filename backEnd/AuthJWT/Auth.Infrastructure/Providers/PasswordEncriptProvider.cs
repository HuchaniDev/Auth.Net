using Auth.Application.Providers;
using Auth.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Providers;

public class PasswordEncriptProvider:IPaswordEncriptProvider
{
    private readonly PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

//    public Task<string> PaswordEncript(string password, PersonaModel persona)
    public Task<string> PaswordEncript(string password)
    {
        string userId = "user123";
        //string hashedPassword = passwordHasher.HashPassword(persona.Id.ToString(), password);
        string hashedPassword = passwordHasher.HashPassword(userId, password);

        return Task.FromResult<string>(hashedPassword);
    }

    public Task<bool>VerifyPassword(string hashedPassword, string password)
    {
        string userId = "user123";
        var verificar = passwordHasher.VerifyHashedPassword(userId, hashedPassword, password);
        
        return  Task.FromResult((verificar == PasswordVerificationResult.Success? true : false));
    } 
}