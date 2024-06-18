using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Auth.Domain.Models.ContenidoIASD;

public class GradeModel
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Reference { get; private set; }
    
    
    [JsonConstructor]
    public GradeModel( string name, string reference)
    {
        Name = name;
        Reference = reference;
    }

    public GradeModel(int id,string name, string reference)
    {
        Id = id;
        Name = name;
        Reference = reference;
    }

    
}