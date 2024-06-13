using Auth.Application.Services;
using Auth.Domain.Models;
using Auth.Infrastructure.Ioc.di;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices();
builder.Services.RegisterProviders();
builder.Services.RegisterRepositories(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline. || endpoint API
app.MapGet("Persona/Get",(PersonaService personaService)=>personaService.Getall());
app.MapPost("Persona/Create", (PersonaModel model, PersonaService personaService) => personaService.Create(model));

app.MapGet("Usuario/Get",(UsuarioService usuarioService)=>usuarioService.GetUsuarios());
app.MapPost("Usuario/Create", (UsuarioModel model, UsuarioService usuarioService) => usuarioService.CreateUsuario(model));

app.MapPost("Login/Autenticate",(AuthService authService, LoginModel login) => authService.Login(login));

app.Run();
