using Auth.Domain.Models;

namespace Auth.Infrastructure.Database.EntityFramework.Entities;

public class PersonaEntity
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Telefono { get; set; }
    public int Ci { get; set; }

    public PersonaModel ToModel()
    {
        return new PersonaModel(
            Id,
            Nombre,
            Apellido,
            Telefono,
            Ci
        );
    }
}