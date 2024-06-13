using Auth.Domain.Models;

namespace Auth.Domain.Repositories;

public interface IUsuarioRepository
{
    Task<UsuarioModel> CreateUsuarioAsync(UsuarioModel model);
    
    Task<UsuarioModel[]> GetUsuariosAsync();
    Task<UsuarioModel> getById(Guid id);

    Task<bool> IsDuplicateUserName(string username);

    Task<UsuarioModel> GetByUsername(string username);
}