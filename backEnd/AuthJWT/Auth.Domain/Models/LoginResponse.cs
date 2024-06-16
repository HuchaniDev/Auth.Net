namespace Auth.Domain.Models;

public class LoginResponse
{
    public string Name { get; private set; }
    public string  Username { get; private set; }
    public string Token { get; private set; }

    public LoginResponse(string name, string username, string token)
    {
        Name = name;
        Username = username;
        Token = token;
    }
}
