using System.Text.Json.Serialization;

namespace Auth.Domain.Models;

public class LoginModel
{
    public string UserName { get; set; }
    public string Clave { get; set; }

    [JsonConstructor]
    public LoginModel( string username,string password)
    {
        UserName = username;
        Clave= password;
    }
    
}