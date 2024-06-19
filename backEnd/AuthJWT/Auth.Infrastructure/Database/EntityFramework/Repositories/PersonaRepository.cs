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
        _authDbContext.SaveChanges();
        return Task.FromResult(result.Entity.ToModel());
    }

    public Task<PersonaModel[]> GetAllAsync()
    {
        var personas = _authDbContext.Persona.Select(entity => entity.ToModel()).ToArray();
        return Task.FromResult(personas);
    }

    public Task<PersonaModel> UpdateAsync(PersonaModel model)
    {
        throw new NotImplementedException();
    }

    public Task Delete(PersonaModel model)
    {
        throw new NotImplementedException();
    }

   
}