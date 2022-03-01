using DuqueVillalba.DinoxTurno.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuqueVillalba.DinoxTurno.Infrastructure.Data.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.IdUsuario)
                 .HasName("PK_Asesores");

            builder.Property(e => e.Contrasena)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Usuario1)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Usuario");
        }
    }
}
