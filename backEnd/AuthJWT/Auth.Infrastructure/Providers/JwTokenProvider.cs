using System.IdentityModel.Tokens.Jwt;
using Auth.Application.Providers;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Auth.Infrastructure.Providers;

public class JwTokenProvider:IJwTokenProvider
{
    private readonly string _secretKey;

    public JwTokenProvider( string secretKey)
    {
        _secretKey = secretKey;
    }
    public Task<string> GenerateToken(string name, string username )
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Name, name),
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim("permission", "escritura"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: "yourdomain.com",
            audience: "yourdomain.com",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return  Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));


    }
}