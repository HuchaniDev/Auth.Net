using Auth.Domain.Models;
using Auth.Infrastructure.Database.EntityFramework.Entities;

namespace Auth.Infrastructure.Database.EntityFramework.Extencions;

public static class UsuarioModelExtencion
{
    public static UsuarioEntity ToEntity(this UsuarioModel model)
    {
        return new UsuarioEntity()
        {
            Username = model.Username,
            Email = model.Email,
            Password_hash = model.Password,
            Persona_id = model.Persona.Id
        };
    }
}