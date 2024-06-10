using Auth.Domain.Common;
using Auth.Domain.Models;

namespace Auth.Domain.Repositories;

public interface IPersonaRepository:IRepository
{
    Task<PersonaModel> CreatePersonaAsync(PersonaModel model);
    
    Task<PersonaModel[]> GetAllAsync();

    Task<PersonaModel> UpdateAsync(PersonaModel model);

    Task Delete(PersonaModel model);
    
    
    //Para usuarios
    Task<UsuarioModel> CreateUsuarioAsync(UsuarioModel model);
    
    Task<bool> IsDuplicateUserName(string username);

    Task<UsuarioModel[]> GetUsuariosAsync();
}