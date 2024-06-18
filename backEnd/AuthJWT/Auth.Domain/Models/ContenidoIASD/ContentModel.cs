using System.Text.Json.Serialization;

namespace Auth.Domain.Models.ContenidoIASD;

public class ContentModel
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int ContentType { get; private set; }
    public string Description { get; private set; }
    
    public ICollection<GradeModel> Grades { get; set; }

    [JsonConstructor]
    public ContentModel(
        string name,
        int type,
        string description
        )
    {
        Name = name;
        ContentType = type;
        Description = description;
    }
    
    public ContentModel(
        int id,
        string name,
        int type,
        string description
    )
    {
        Id = id;
        Name = name;
        ContentType = type;
        Description = description;
    }
}