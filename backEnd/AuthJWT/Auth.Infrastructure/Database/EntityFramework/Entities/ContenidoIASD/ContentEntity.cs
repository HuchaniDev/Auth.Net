using Auth.Domain.Models.ContenidoIASD;

namespace Auth.Infrastructure.Database.EntityFramework.Entities.ContenidoIASD;

public class ContentEntity
{
    public int id { get; set;}
    public string name { get; set; }
    public int contentType { get; set; }
    public string description { get; set; }

    ContentModel ToModel()
    {
        return new ContentModel(id, name, contentType, description);
    }
}