using DuqueVillalba.DinoxTurno.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DuqueVillalba.DinoxTurno.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        

        [HttpPost]
        public string Login(LoginDto loginDto)
        {
            return "Ok "+ loginDto.user;
        }

        [HttpGet]
        public string Login()
        {
            return "Ok ";
        }


    }
}
