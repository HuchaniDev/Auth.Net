using Auth.Application.Exceptions.ContenidoIASD;
using Auth.Domain.Models.ContenidoIASD;
using Auth.Domain.Repositories;
using Auth.Infrastructure.Database.EntityFramework.Extencions.ContenidoIASD;

namespace Auth.Infrastructure.Database.EntityFramework.Repositories;

public class ContenidoRepository : IContenidoRepository
{
    private readonly AuthDbContext _authDbContext;

    public ContenidoRepository(AuthDbContext authDbContext)
    {
        _authDbContext = authDbContext;
    }
    
    public Task<GradeModel> CreateGradeAsync(GradeModel model)
    {
        var result = _authDbContext.Grade.Add(model.ToEntity());
        _authDbContext.SaveChanges();

        return Task.FromResult<GradeModel>(result.Entity.ToModel());
    }

    public Task<GradeModel[]> GetGradeAsync()
    {
        var Grados = _authDbContext.Grade.Select(entity => entity.ToModel()).ToArray();
        return Task.FromResult(Grados);
    }

    public Task<ContentModel> CreateContentAsync(ContentModel model)
    {
        var result = _authDbContext.Content.Add(model.ToEntity());
        _authDbContext.SaveChanges();
        return Task.FromResult<ContentModel>(result.Entity.ToModel());
    }

    public Task<ContentModel[]> GetContentAsync()
    {
        var contenidos = _authDbContext.Content.Select(entity => entity.ToModel()).ToArray();
        return Task.FromResult(contenidos);
    }

    public Task<ContentModel> GetContentByIdAsync(int id)
    {
        var contenido = _authDbContext.Content.Where(c => c.id == id).FirstOrDefault();
        if (contenido == null) return Task.FromResult<ContentModel>(null);
            
        return Task.FromResult<ContentModel>(contenido.ToModel());
    }


    public Task<GradeContentModel[]> GetGradeContentById(int id_grade)
    {
        var Grade_Content = _authDbContext.ContentGrade.Where(gc => gc.grade_id == id_grade).ToArray();
        var content = _authDbContext.Content.ToArray();
        List<GradeContentModel> gradeContent = new List<GradeContentModel>();

        foreach (var contenido in Grade_Content)
        {
            var cont = content.Where(c => c.id == contenido.content_id).FirstOrDefault();
            if(cont != null) gradeContent.Add(cont.ToGradeContent());
        }

        return Task.FromResult(gradeContent.ToArray());
    }

    public Task<Favorites> CreateFavoriteAsync(string userId, int id)
    {
        var model = new Favorites(Guid.Parse(userId), id);
        var favorite = _authDbContext.favorites.Add(model.ToEntity());
        _authDbContext.SaveChanges();

        return Task.FromResult(favorite.Entity.ToModel());
    }

    public Task<Favorites[]> GetFavorites(Guid id)
    {
        var favorites = _authDbContext.favorites.Where(f => f.user_id == id).Select(v=>v.ToModel()).ToArray();
        return Task.FromResult<Favorites[]>(favorites);
    }

    public Task<string> DeleteFavorite(int id)
    {
        throw new NotImplementedException();
    }
}