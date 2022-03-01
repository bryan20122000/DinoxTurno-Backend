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
    public class TurnoConfig : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.HasKey(e => e.IdTurno);

            builder.Property(e => e.FechaHoraAtendido).HasColumnType("datetime");

            builder.Property(e => e.FechaHoraTurno)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.IdEstado).HasComment("0 = Pendiente\r\n1 = Atendido\r\n2 = Ausente");

            builder.HasOne(d => d.IdAsesorNavigation)
                .WithMany(p => p.Turnos)
                .HasForeignKey(d => d.IdAsesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Turnos_Asesores");

            builder.HasOne(d => d.IdModuloNavigation)
                .WithMany(p => p.Turnos)
                .HasForeignKey(d => d.IdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Turnos_Modulos");
        }
    }
}
