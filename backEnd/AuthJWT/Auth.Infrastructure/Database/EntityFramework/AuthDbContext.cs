using Auth.Domain.Models;
using Auth.Infrastructure.Database.EntityFramework.Entities;
using Auth.Infrastructure.Database.EntityFramework.Entities.ContenidoIASD;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Database.EntityFramework;

public class AuthDbContext:DbContext
{
    public DbSet<PersonaEntity>Persona { get; set; }
    public DbSet<UsuarioEntity>Usuario { get; set; }
    public DbSet<GradeEntity>Grade { get; set; }
    public DbSet<ContentEntity>Content { get; set; }
    public AuthDbContext(DbContextOptions<AuthDbContext> options):base(options){}
    
}