using Auth.Application.Exceptions;
using Auth.Domain.Models;
using Auth.Domain.Repositories;

namespace Auth.Application.Services;

public class PersonaService
{
    private readonly IPersonaRepository _personaRepository;

    public PersonaService(IPersonaRepository personaRepository)
    {
        _personaRepository = personaRepository;
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
        if (await _personaRepository.IsDuplicateUserName(model.Username)) throw new UsernameDuplicateException(model.Username);

        return await _personaRepository.CreateUsuarioAsync(model);
    }
}