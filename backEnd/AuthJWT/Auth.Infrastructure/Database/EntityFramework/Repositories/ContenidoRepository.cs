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

        return Task.FromResult(result.Entity.ToModel());
    }

    public Task<GradeModel[]> GetGradeAsync()
    {
        var Grados = _authDbContext.Grade.Select(entity => entity.ToModel()).ToArray();
        return Task.FromResult(Grados);
    }

    public Task<ContentModel> CreateContentAsync(ContentModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ContentModel[]> GetContentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Favorites> CreateFavoriteAsync(Favorites model)
    {
        throw new NotImplementedException();
    }

    public Task<Favorites[]> GetFavorites(Guid id)
    {
        throw new NotImplementedException();
    }
}