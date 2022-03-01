using AutoMapper;
using DuqueVillalba.DinoxTurno.Core.Dto;
using DuqueVillalba.DinoxTurno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuqueVillalba.DinoxTurno.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<LoginDto, Usuario>();
            CreateMap<Usuario, LoginDto>();
        }


    }
}
