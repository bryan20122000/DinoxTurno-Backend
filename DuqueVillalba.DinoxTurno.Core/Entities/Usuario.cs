using System;
using System.Collections.Generic;

#nullable disable

namespace DuqueVillalba.DinoxTurno.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Turnos = new HashSet<Turno>();
        }

        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasena { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
