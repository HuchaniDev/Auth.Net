using Auth.Application.Providers;
using Auth.Application.Services;
using Auth.Domain.Adapters;
using Auth.Domain.Repositories;
using Auth.Infrastructure.Database.EntityFramework;
using Auth.Infrastructure.Database.EntityFramework.Repositories;
using Auth.Infrastructure.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.Ioc.di;

public static class DependencyInjectionProject
{
    public static IServiceCollection RegisterProviders(this IServiceCollection collection)
    {
        collection.AddTransient<IPaswordEncriptProvider, PasswordEncriptProvider>();
        collection.AddTransient<IPasswordEncriptAdapter, PasswordEncriptAdapter>();

        return collection;
    }
    
    public static IServiceCollection RegisterServices(this IServiceCollection collection)
    {
        collection.AddTransient<PersonaService>();
        return collection;
    }
    
    public static IServiceCollection RegisterRepositories(this IServiceCollection collection,
        IConfiguration configuration)
    {
        collection.AddDbContext<AuthDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("localDB"));
        });

        collection.AddTransient<IPersonaRepository, PersonaRepository>();

        return collection;
    }
}