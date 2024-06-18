using Auth.Domain.Models.ContenidoIASD;

namespace Auth.Infrastructure.Database.EntityFramework.Entities.ContenidoIASD;

public class GradeEntity
{
    public int id { get; set; }
    public string name{ get; set; }
    public string reference { get; set; }

    public GradeModel ToModel()
    {
        return new GradeModel(id, name, reference);
    }
}