using Auth.Domain.Models.ContenidoIASD;
using Auth.Infrastructure.Database.EntityFramework.Entities.ContenidoIASD;

namespace Auth.Infrastructure.Database.EntityFramework.Extencions.ContenidoIASD;

public static class FavoriteExtencion
{
    public static FavoriteEntity ToEntity(this Favorites model)
    {
        return new FavoriteEntity()
        {
            user_id = model.UserId,
            content_id = model.ContentId,
        };
    }
}