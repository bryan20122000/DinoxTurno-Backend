using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DuqueVillalba.DinoxTurno.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuqueVillalba.DinoxTurno.Infrastructure.Data.Configurations
{
    public class ModuloConfig : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {

            builder.HasKey(e => e.IdModulo)
                    .HasName("PK_Modulo");

            builder.Property(e => e.Numero)
                    .HasMaxLength(2)
                    .IsUnicode(false);
           
        }
    }
}
