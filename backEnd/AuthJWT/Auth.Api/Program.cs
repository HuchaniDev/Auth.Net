using Auth.Application.Services;
using Auth.Domain.Models;
using Auth.Infrastructure.Ioc.di;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices();
builder.Services.RegisterRepositories(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline. || endpoint API
app.Map("Persona/Get",(PersonaService personaService)=>personaService.Getall());
app.Map("Persona/Create", (PersonaModel model, PersonaService personaService) => personaService.Create(model));


app.Run();
