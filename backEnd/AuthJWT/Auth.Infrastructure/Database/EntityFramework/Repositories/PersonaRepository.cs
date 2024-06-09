using Auth.Domain.Models;
using Auth.Domain.Repositories;
using Auth.Infrastructure.Database.EntityFramework.Extencions;

namespace Auth.Infrastructure.Database.EntityFramework.Repositories;

public class PersonaRepository:IPersonaRepository
{
    private readonly AuthDbContext _authDbContext;
    
    public PersonaRepository( AuthDbContext authDbContext)
    {
        _authDbContext = authDbContext;
    }
    
    public Task<PersonaModel> CreatePersonaAsync(PersonaModel model)
    {
        var result = _authDbContext.Persona.Add(model.ToEntity());
        _authDbContext.SaveChangesAsync();
        return Task.FromResult(result.Entity.ToModel());
    }

    public Task<PersonaModel[]> GetAllAsync()
    {
        var Personas = _authDbContext.Persona.Select(entity => entity.ToModel()).ToArray();
        return Task.FromResult(Personas);
    }

    public Task<PersonaModel> UpdateAsync(PersonaModel model)
    {
        throw new NotImplementedException();
    }

    public Task Delete(PersonaModel model)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioModel> CreateUsuarioAsync(UsuarioModel model)
    {
        var result = _authDbContext.Usuario.Add(model.ToEntity());
        _authDbContext.SaveChanges();
        return Task.FromResult(result.Entity.ToModel(model));
    }

    public Task<bool> IsDuplicateUserName(string username)
    {
        var usernames = _authDbContext.Usuario.Where(u => u.Username.ToLower().Contains((username.ToLower()))).Count();

        return Task.FromResult(usernames > 0);
    }
}