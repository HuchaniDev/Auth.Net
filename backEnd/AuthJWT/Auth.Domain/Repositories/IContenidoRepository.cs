using Auth.Domain.Common;
using Auth.Domain.Models.ContenidoIASD;

namespace Auth.Domain.Repositories;

public interface IContenidoRepository:IRepository
{
    Task<GradeModel>CreateGradeAsync(GradeModel model);
    Task<GradeModel[]> GetGradeAsync();

    Task<ContentModel>CreateContentAsync(ContentModel model);
    Task<ContentModel[]>GetContentAsync(int id);

    Task<Favorites> CreateFavoriteAsync(Favorites model);
    Task<Favorites[]> GetFavorites(Guid id);
}