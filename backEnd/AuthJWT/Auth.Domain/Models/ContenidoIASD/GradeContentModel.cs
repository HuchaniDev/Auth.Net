namespace Auth.Domain.Models.ContenidoIASD;

public class GradeContentModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public GradeContentModel(int id_content , string name)
    {
        Id = id_content;
        Name = name;
    }
}