using DuqueVillalba.DinoxTurno.Core.Dto;
using DuqueVillalba.DinoxTurno.Core.Entities;
using DuqueVillalba.DinoxTurno.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DuqueVillalba.DinoxTurno.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly IUsuarioRepository usuarioRepository;

        public UserController(IConfiguration configuration, IUsuarioRepository _usuarioRepository)
        {
            _configuration = configuration;
            usuarioRepository = _usuarioRepository;
        }

        [HttpPost]
        public string Login(LoginDto loginDto)
        {
            // "Ok " + loginDto.user;

            // var claims = new[] { new Claim("UserData", JsonConvert.SerializeObject(loginDto)) };

            var user = new LoginDto
            {
                user = "Eduardo",
                password = "admin@kodoti.com"
            };

            // Leemos el secret_key desde nuestro appseting
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            // Creamos los claims (pertenencias, características) del usuario
            var claims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.user),
            new Claim(ClaimTypes.Email, user.password) };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }

        [HttpGet]
        public string Login()
        {
            return "Ok ";
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await usuarioRepository.GetAll();
            return Ok(users);
        }

    }
}
