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
    public class RolPermisoConfig : IEntityTypeConfiguration<RolPermiso>
    {
        public void Configure(EntityTypeBuilder<RolPermiso> builder)
        {
            builder.ToTable("RolPermiso");
        }
    }
}
