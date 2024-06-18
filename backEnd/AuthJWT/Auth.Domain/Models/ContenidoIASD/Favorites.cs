using System.Text.Json.Serialization;

namespace Auth.Domain.Models.ContenidoIASD;

public class Favorites
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public int ContentId{ get; private set; }

    [JsonConstructor]
    public Favorites( Guid userId, int contentId)
    {
        UserId = userId;
        ContentId = contentId;
    }
}