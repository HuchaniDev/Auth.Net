using System.Text.Json.Serialization;

namespace Auth.Domain.Models.ContenidoIASD;

public class Favorites
{
    public int Id { get; private set; }
    public Guid UserId { get; private set; }
    public int ContentId{ get; private set; }

    [JsonConstructor]
    public Favorites( Guid userId, int contentId)
    {
        UserId = userId;
        ContentId = contentId;
    }

    public Favorites(int id, Guid userId,int contentId)
    {
        Id = id;
        UserId = userId;
        ContentId = contentId;
    }
}