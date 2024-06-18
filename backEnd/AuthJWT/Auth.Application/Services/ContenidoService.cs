using Auth.Domain.Models.ContenidoIASD;
using Auth.Domain.Repositories;

namespace Auth.Application.Services;

public class ContenidoService
{
    private readonly IContenidoRepository _contenidoRepository;

    public ContenidoService(IContenidoRepository contenidoRepository)
    {
        _contenidoRepository = contenidoRepository;
    }
    // crear grade
    public async Task<GradeModel> createGrade(GradeModel grade)
    {
        return await _contenidoRepository.CreateGradeAsync(grade);
    }

    public async Task<GradeModel[]> getGrade()
    {
        return await _contenidoRepository.GetGradeAsync();
    }
    
    // crear contenido
    public async Task<ContentModel> createContent(ContentModel content)
    {
        return await _contenidoRepository.CreateContentAsync(content);
    }
}