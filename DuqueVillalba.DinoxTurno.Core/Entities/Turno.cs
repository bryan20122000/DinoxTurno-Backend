using System;
using System.Collections.Generic;

#nullable disable

namespace DuqueVillalba.DinoxTurno.Core.Entities
{
    public partial class Turno
    {
        public int IdTurno { get; set; }
        public int IdAsesor { get; set; }
        public int IdModulo { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaHoraTurno { get; set; }
        public DateTime? FechaHoraAtendido { get; set; }

        public virtual Usuario IdAsesorNavigation { get; set; }
        public virtual Modulo IdModuloNavigation { get; set; }
    }
}
