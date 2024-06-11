using Auth.Application.Exceptions;
using Auth.Application.Providers;
using Auth.Domain.Adapters;
using Auth.Domain.Models;
using Auth.Domain.Repositories;

namespace Auth.Application.Services;

public class PersonaService
{
    private readonly IPersonaRepository _personaRepository;
    private readonly IPasswordEncriptAdapter _passwordEncriptAdapter;
    private readonly IPaswordEncriptProvider _paswordEncriptProvider;

    public PersonaService(
        IPersonaRepository personaRepository,
        IPasswordEncriptAdapter passwordEncriptAdapter,
        IPaswordEncriptProvider paswordEncriptProvider
        )
    {
        _personaRepository = personaRepository;
        _paswordEncriptProvider = paswordEncriptProvider;
        _passwordEncriptAdapter = _passwordEncriptAdapter;
    }

    public async Task<PersonaModel> Create(PersonaModel personaModel)
    {
        return await _personaRepository.CreatePersonaAsync(personaModel);
    }

    public async Task<PersonaModel[]> Getall()
    {
        return await _personaRepository.GetAllAsync();
    }
    
    
    //para Usuarios
    public async Task<UsuarioModel> CreateUsuario(UsuarioModel model)
    {
        //var password_hash = _passwordEncriptAdapter.PasswordEncript(model.Password);
        var password_hash =  await _paswordEncriptProvider.PaswordEncript(model.Password);
        
        model.setPasswordHash(password_hash);
        
        if (await _personaRepository.IsDuplicateUserName(model.Username)) throw new UsernameDuplicateException(model.Username);

        return await _personaRepository.CreateUsuarioAsync(model);
    }
    
    public async Task<UsuarioModel[]> GetUsuarios()
    {
        return await _personaRepository.GetUsuariosAsync();
    }
}