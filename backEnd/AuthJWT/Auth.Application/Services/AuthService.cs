using Auth.Application.Exceptions;
using Auth.Application.Providers;
using Auth.Domain.Models;
using Auth.Domain.Repositories;

namespace Auth.Application.Services;

public class AuthService
{
    private readonly IPaswordEncriptProvider _paswordEncriptProvider;
    private readonly IUsuarioRepository _UsuarioRepository;
    private readonly IPersonaRepository _personaRepository;

    public AuthService(IPaswordEncriptProvider paswordEncriptProvider,
                       IUsuarioRepository usuarioRepository,
                       IPersonaRepository personaRepository
                       )
    {
        _paswordEncriptProvider = paswordEncriptProvider;
        _UsuarioRepository = usuarioRepository;
        _personaRepository = personaRepository;
    }
    
    
    public async Task<string> Login(LoginModel model)
    {
        var usuario = await _UsuarioRepository.GetByUsername(model.UserName);
        if (usuario == null) throw new UserNoExistException();
        var IspasswordCorrect = _paswordEncriptProvider.VerifyPassword(usuario.Password, model.Clave);

        if (IspasswordCorrect.Result)
        {
            return await Task.FromResult("login");
        }

        throw new PasswordIncorrectException();
    }
}
