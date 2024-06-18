using Auth.Domain.Models.ContenidoIASD;
using Auth.Infrastructure.Database.EntityFramework.Entities.ContenidoIASD;

namespace Auth.Infrastructure.Database.EntityFramework.Extencions.ContenidoIASD;

public static class GradeModelExtencion
{
    public static GradeEntity ToEntity(this GradeModel model)
    {
        return new GradeEntity()
        {
            name = model.Name,
            reference = model.Reference
        };

    }
}