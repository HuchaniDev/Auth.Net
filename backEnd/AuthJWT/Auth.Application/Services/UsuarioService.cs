using Auth.Application.Exceptions;
using Auth.Application.Providers;
using Auth.Domain.Models;
using Auth.Domain.Repositories;

namespace Auth.Application.Services;

public class UsuarioService
{
    private IPaswordEncriptProvider _paswordEncriptProvider;
    private IPersonaRepository _personaRepository;
    private IUsuarioRepository _usuarioRepository;

    public UsuarioService(IPaswordEncriptProvider paswordEncriptProvider,
                        IPersonaRepository personaRepository,
                        IUsuarioRepository usuarioRepository)
    {
        _paswordEncriptProvider = paswordEncriptProvider;
        _personaRepository = personaRepository;
        _usuarioRepository = usuarioRepository;
    }
    public async Task<UsuarioModel> CreateUsuario(UsuarioModel model)
    {
        //var password_hash =  _passwordEncriptAdapter.PasswordEncript(model.Password);
        var password_hash =  await _paswordEncriptProvider.PaswordEncript(model.Password);
        model.setPasswordHash(password_hash);
        
        if (await _usuarioRepository.IsDuplicateUserName(model.Username)) throw new UsernameDuplicateException(model.Username);
        
        return await _usuarioRepository.CreateUsuarioAsync(model);
    }
    
    public async Task<UsuarioModel[]> GetUsuarios()
    {
        return await _usuarioRepository.GetUsuariosAsync();
    }
}