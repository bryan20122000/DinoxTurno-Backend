using System;
using System.Collections.Generic;

#nullable disable

namespace DuqueVillalba.DinoxTurno.Core.Entities
{
    public partial class Modulo
    {
        public Modulo()
        {
            Turnos = new HashSet<Turno>();
        }

        public int IdModulo { get; set; }
        public string Numero { get; set; }

        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
