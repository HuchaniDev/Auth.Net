
using Auth.Application.Providers;
using Auth.Domain.Models;
using Auth.Domain.Repositories;

namespace Auth.Application.Services;

public class PersonaService
{
    private readonly IPersonaRepository _personaRepository;

    private readonly IPaswordEncriptProvider _paswordEncriptProvider;

    public PersonaService(
        IPersonaRepository personaRepository,
        IPaswordEncriptProvider paswordEncriptProvider
        )
    {
        _personaRepository = personaRepository;
        _paswordEncriptProvider = paswordEncriptProvider;
    
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
}