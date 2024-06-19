using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Auth.Domain.Exceptions;

namespace Auth.Domain.Models;

public class UsuarioModel
{
    public Guid Id { get; set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public PersonaModel Persona { get; set; }


    [JsonConstructor]
    /*public UsuarioModel(
        Guid id, 
        string nombre, 
        string apellido, 
        int telefono, 
        int ci,
        string username,
        string email,
        string password
        ) : base(id, nombre, apellido, telefono, ci)
    {
        Username = username;
        Email = ValidateEmail(email);
        Password = ValidatePassword(password);
    }
*/
    public UsuarioModel(
        PersonaModel persona,
        string username,
        string email,
        string password
    ) 
    {
        Username = username;
        Email = ValidateEmail(email);
        Password = ValidatePassword(password);
        Persona= persona;
    }
    
    public UsuarioModel(
        PersonaModel persona,
        Guid id,
        string username,
        string email,
        string password
    )
    {
        Id = id;
        Username = username;
        Email = ValidateEmail(email);
        Password = ValidatePassword(password);
        Persona= persona;
    }
    
    private static string ValidatePassword(string password)
    {
        if (new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@#$/+%^=&*-]{4,}$").Match(password).Success) return password;
        throw new InvalidPasswordException();
    }

    public void setPasswordHash(string passwordHash) => Password = passwordHash;
    
    private static string ValidateEmail(string email)
    {
        if (new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(email).Success) return email;
        throw new InvalidEmailException();
    }
    
}