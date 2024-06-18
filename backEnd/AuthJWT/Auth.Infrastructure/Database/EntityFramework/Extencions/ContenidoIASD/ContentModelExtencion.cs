using Auth.Domain.Models.ContenidoIASD;
using Auth.Infrastructure.Database.EntityFramework.Entities.ContenidoIASD;

namespace Auth.Infrastructure.Database.EntityFramework.Extencions.ContenidoIASD;

public static class ContentModelExtencion
{
    public static ContentEntity ToEntity(this ContentModel model)
    {
        return new ContentEntity()
        {
            name = model.Name,
            contentType = model.ContentType,
            description = model.Description
        };
    }
}