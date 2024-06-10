using Auth.Domain.Models;

namespace Auth.Infrastructure.Database.EntityFramework.Entities;

public class UsuarioEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password_hash { get; set; }
    public Guid Persona_id { get; set; }

    public UsuarioModel ToModel(PersonaModel persona)
    {
        return new UsuarioModel(
            persona,
            Username,
            Email,
            Password_hash
        );
    }
}