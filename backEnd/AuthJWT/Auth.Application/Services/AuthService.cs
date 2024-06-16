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
    private readonly IJwTokenProvider _jwTokenProvider;

    public AuthService(IPaswordEncriptProvider paswordEncriptProvider,
                       IUsuarioRepository usuarioRepository,
                       IPersonaRepository personaRepository,
                       IJwTokenProvider jwTokenProvider
                       )
    {
        _paswordEncriptProvider = paswordEncriptProvider;
        _UsuarioRepository = usuarioRepository;
        _personaRepository = personaRepository;
        _jwTokenProvider = jwTokenProvider;
    }
    
    public async Task<LoginResponse> Login(LoginModel model)
    {
        var usuario = await _UsuarioRepository.GetByUsername(model.UserName);
        if (usuario == null) throw new UserNoExistException();
        
        var IspasswordCorrect = _paswordEncriptProvider.VerifyPassword(usuario.Password, model.Clave);

        if (IspasswordCorrect.Result)
        {
            var token = await _jwTokenProvider.GenerateToken(usuario.Persona.Nombre, usuario.Username);
            return await Task.FromResult(new LoginResponse(usuario.Persona.Nombre, usuario.Username, token));
        }

        throw new PasswordIncorrectException();
    }
    
}
