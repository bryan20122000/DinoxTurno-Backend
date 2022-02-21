
using DuqueVillalba.DinoxTurno.Core.Entities;
using DuqueVillalba.DinoxTurno.Core.Interfaces;
using DuqueVillalba.DinoxTurno.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuqueVillalba.DinoxTurno.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DinoxTurnoContext context;

        public UsuarioRepository(DinoxTurnoContext _context)
        {
            context = _context;
        }




        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var users = await context.Usuarios.ToListAsync();

            return users;
        }

    }
}
