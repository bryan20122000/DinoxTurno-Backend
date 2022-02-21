using System;
using System.Collections.Generic;

#nullable disable

namespace DuqueVillalba.DinoxTurno.Core.Entities
{
    public partial class RolPermiso
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdPermiso { get; set; }
    }
}
