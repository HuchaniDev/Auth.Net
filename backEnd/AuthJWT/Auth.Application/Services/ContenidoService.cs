using Auth.Application.Exceptions.ContenidoIASD;
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

    public async Task<ContentModel[]> getContent()
    {
        return await _contenidoRepository.GetContentAsync();
    }

    // obtener grade Contenido
    public async Task<GradeContentModel[]> getGradeContent(int id)
    {
        return await _contenidoRepository.GetGradeContentById(id);
    }
    
    
    //obtener material
    public async Task<ContentModel> ContentGetById(int id)
    {
        ContentModel content = await _contenidoRepository.GetContentByIdAsync(id);

        if (content != null) return await Task.FromResult(content);
        
        throw new NoExisteContenidoException();
    }
    
    //favorites
    public async Task<Favorites> saveFavorite(string userId,int id)
    {
        return await _contenidoRepository.CreateFavoriteAsync(userId,id);
    }

    public async Task<Favorites[]> getFavorites(Guid id)
    {
        return await _contenidoRepository.GetFavorites(id);
    }
}