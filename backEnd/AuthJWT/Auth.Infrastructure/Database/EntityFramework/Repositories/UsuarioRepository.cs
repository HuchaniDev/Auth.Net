using Auth.Domain.Models;
using Auth.Domain.Repositories;
using Auth.Infrastructure.Database.EntityFramework.Extencions;

namespace Auth.Infrastructure.Database.EntityFramework.Repositories;

public class UsuarioRepository:IUsuarioRepository
{

    private readonly AuthDbContext _authDbContext;
    
    public UsuarioRepository( AuthDbContext authDbContext)
    {
        _authDbContext = authDbContext;
    }
    
    public Task<UsuarioModel> CreateUsuarioAsync(UsuarioModel model)
    {
        var result = _authDbContext.Usuario.Add(model.ToEntity());
        _authDbContext.SaveChanges();
        
        return Task.FromResult(result.Entity.ToModel(model.Persona));
    }

    public Task<bool> IsDuplicateUserName(string username)
    {
        var usernames = _authDbContext.Usuario.Where(u => u.Username.ToLower().Contains((username.ToLower()))).Count();

        return Task.FromResult(usernames > 0);
    }

    public Task<UsuarioModel[]> GetUsuariosAsync()
    {
        List<UsuarioModel> usuarios= new List<UsuarioModel>();
        var Personas = _authDbContext.Persona.Select(entity => entity.ToModel()).ToArray();
        var Usuarios = _authDbContext.Usuario.ToList();
          
        foreach (var persona in Personas)
        {
            var user = Usuarios.Where(u =>u.Persona_id==persona.Id).FirstOrDefault();
            if(user != null) usuarios.Add(user.ToModel(persona));
            
        }
        /*foreach (var persona in Personas)
        {
            var user = _authDbContext.Usuario.Where(p => p.Persona_id == persona.Id).FirstOrDefault();
            if(user != null) usuarios.Add(user.ToModel(persona));
            
        }*/

        return Task.FromResult(usuarios.ToArray());
    }
    
    public Task<UsuarioModel> getById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioModel> GetByUsername(string username)
    {
        var user = _authDbContext.Usuario.Where(u => u.Username == username).FirstOrDefault();

        if (user != null)
        {
            var persona = _authDbContext.Persona.Where(p => p.Id == user.Persona_id).FirstOrDefault();
            return Task.FromResult<UsuarioModel>(user.ToModel(persona.ToModel()));
        }

        return Task.FromResult<UsuarioModel>(null);
    }
}