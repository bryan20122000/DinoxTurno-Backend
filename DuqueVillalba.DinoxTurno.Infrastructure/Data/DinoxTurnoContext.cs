using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DuqueVillalba.DinoxTurno.Core.Entities;
using DuqueVillalba.DinoxTurno.Infrastructure.Data.Configurations;

#nullable disable

namespace DuqueVillalba.DinoxTurno.Infrastructure.Data
{
    public partial class DinoxTurnoContext : DbContext
    {
        public DinoxTurnoContext()
        {
        }

        public DinoxTurnoContext(DbContextOptions<DinoxTurnoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<RolPermiso> RolPermisos { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new ModuloConfig());

            modelBuilder.ApplyConfiguration(new PermisoConfig());

            modelBuilder.ApplyConfiguration(new RolPermisoConfig());

            modelBuilder.ApplyConfiguration(new RoleConfig());

            modelBuilder.ApplyConfiguration(new TurnoConfig());

            modelBuilder.ApplyConfiguration(new UsuarioConfig());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
