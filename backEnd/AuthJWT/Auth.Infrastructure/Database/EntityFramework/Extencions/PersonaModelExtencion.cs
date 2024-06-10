using Auth.Domain.Models;
using Auth.Infrastructure.Database.EntityFramework.Entities;

namespace Auth.Infrastructure.Database.EntityFramework.Extencions;

public static class PersonaModelExtencion
{
    public static PersonaEntity ToEntity(this PersonaModel model)
    {
        return new PersonaEntity()
        {
            Id = model.Id,
            Nombre = model.Nombre,
            Apellido = model.Apellido,
            Telefono = model.Telefono,
            Ci = model.Ci
        };
    }
}