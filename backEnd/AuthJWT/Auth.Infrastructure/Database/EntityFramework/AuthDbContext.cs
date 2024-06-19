
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
    public DbSet<GradeContentEntity>ContentGrade { get; set; }
    public DbSet<FavoriteEntity> favorites { get; set; }
    public AuthDbContext(DbContextOptions<AuthDbContext> options):base(options){}
    
}