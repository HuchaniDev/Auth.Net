using System.Text;
using Auth.Application.Services;
using Auth.Domain.Models;
using Auth.Infrastructure.Ioc.di;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices();
builder.Services.RegisterProviders();
builder.Services.RegisterRepositories(builder.Configuration);

// Read secret key from configuration
var secretKey = builder.Configuration.GetSection("JwtSettings:SecretKey").Value;

// Register secret key as singleton
builder.Services.AddSingleton(secretKey);

//token verified
var key = Encoding.ASCII.GetBytes("your_longer_secret_key_here_with_at_least_32_characters");

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline. || endpoint API
app.MapGet("Persona/Get",[Authorize](PersonaService personaService)=>personaService.Getall());
app.MapPost("Persona/Create", [Authorize](PersonaModel model, PersonaService personaService) => personaService.Create(model));

app.MapGet("Usuario/Get",[Authorize](UsuarioService usuarioService)=>usuarioService.GetUsuarios());
app.MapPost("Usuario/Create",[Authorize] (UsuarioModel model, UsuarioService usuarioService) => usuarioService.CreateUsuario(model));

app.MapPost("Login/Autenticate", (LoginModel login, AuthService authService) => authService.Login(login));

app.Run();
