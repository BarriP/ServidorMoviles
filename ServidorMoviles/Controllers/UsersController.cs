using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServidorMoviles.Models;
using ServidorMoviles.Models.Form;
using ServidorMoviles.Services;

namespace ServidorMoviles.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository repo) => _userRepository = repo;

        // GET api/Users
        [ProducesResponseType(typeof(IEnumerable<Usuario>), 200)]
        [HttpGet("")]
        public IActionResult GetAllUsers() => Ok(_userRepository.GetUsuarios());

        // GET api/Users/5
        [ProducesResponseType(typeof(Usuario), 200)]
        [ProducesResponseType(typeof(Usuario), 404)]
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.GetUsuario(id);
            if (user != null)
                return Ok(user);
            else
                return NotFound(new {Msg = $"Usuario con id[{id}] no encontrado"});
        }

        // POST api/Users
        [HttpPost("")]
        [ProducesResponseType(typeof(Usuario), 201)]
        [ProducesResponseType(typeof(Usuario), 400)]
        public IActionResult NewUser([FromBody] UsuarioCreate newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { ErrorMsg = "No se ha proporcionado un usuario valido" });

            var userData = new Usuario
            {
                Username = newUser.Username,
                Password = newUser.Password,
                Mail = newUser.Mail,
                Name = newUser.Name
            };

            var result = _userRepository.NewUsuario(userData);

            if (result == null)
                return BadRequest(new {ErrorMsg = "No se ha proporcionado un usuario valido"});
            else
                return Created("", result);
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //TODO
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            if (_userRepository.DeleteUser(id))
            {
                _userRepository.Save();
                return Ok(new {Msg = $"Usuario [{id}] borrado"});
            }
            else
                return NotFound(new {Msg = $"Usuario [{id}] no se ha encontrado"});
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(Usuario), 200)]
        [ProducesResponseType(typeof(Usuario), 404)]
        public IActionResult Login(string username, string password)
        {
            var user = _userRepository.GetUsuario(username, password);
            if (user != null)
                return Ok(user);
            else
                return NotFound(new {Msg = $"Usuario con username[{username}] no encontrado"});
        }
    }
}