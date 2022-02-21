using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DuqueVillalba.DinoxTurno.Core.Entities;

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

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("PK_Modulo");

                entity.Property(e => e.Numero)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso);

                entity.Property(e => e.Display)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Permiso1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Permiso");
            });

            modelBuilder.Entity<RolPermiso>(entity =>
            {
                entity.ToTable("RolPermiso");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.IdTurno);

                entity.Property(e => e.FechaHoraAtendido).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraTurno)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEstado).HasComment("0 = Pendiente\r\n1 = Atendido\r\n2 = Ausente");

                entity.HasOne(d => d.IdAsesorNavigation)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.IdAsesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Turnos_Asesores");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Turnos_Modulos");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Asesores");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
