using Auth.Domain.Models.ContenidoIASD;

namespace Auth.Infrastructure.Database.EntityFramework.Entities.ContenidoIASD;

public class FavoriteEntity
{
    public int id { get; set; }
    public Guid user_id { get; set; }
    public int content_id { get; set; }

    public Favorites ToModel()
    {
        return new Favorites(id,user_id, content_id);
    }
}