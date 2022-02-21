
using DuqueVillalba.DinoxTurno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuqueVillalba.DinoxTurno.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<IEnumerable<Usuario>> GetAll();
    }
}
