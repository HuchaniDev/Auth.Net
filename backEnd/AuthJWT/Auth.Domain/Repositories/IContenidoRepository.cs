using Auth.Domain.Common;
using Auth.Domain.Models.ContenidoIASD;

namespace Auth.Domain.Repositories;

public interface IContenidoRepository:IRepository
{
    Task<GradeModel>CreateGradeAsync(GradeModel model);
    Task<GradeModel[]> GetGradeAsync();

    Task<ContentModel>CreateContentAsync(ContentModel model);
    Task<ContentModel[]> GetContentAsync();
    Task<ContentModel> GetContentByIdAsync(int id);
    
    //
    Task<GradeContentModel[]> GetGradeContentById(int id_grade);
    

    Task<Favorites> CreateFavoriteAsync(string userId, int id);
    Task<Favorites[]> GetFavorites(Guid id);
    Task<string> DeleteFavorite(int id);
}