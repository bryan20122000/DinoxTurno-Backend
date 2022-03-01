using DuqueVillalba.DinoxTurno.Core.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuqueVillalba.DinoxTurno.Infrastructure.Validators
{
    public class UsuarioValidator:AbstractValidator<LoginDto>
    {
        public UsuarioValidator() {
            RuleFor(login => login.user)
                .NotNull();
            RuleFor(login => login.password)
             .NotNull().Length(6,10);
            

        }
    

    }
}
