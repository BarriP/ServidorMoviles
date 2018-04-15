using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FSharp.Collections;
using Microsoft.VisualBasic.CompilerServices;
using ServidorMoviles.Models;
using ServidorMoviles.Models.Form;
using ServidorMoviles.Services;
using ServidorMoviles.Utils;

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
        [ProducesResponseType(typeof(ErrorMsg), 404)]
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.GetUsuario(id);
            if (user != null)
                return Ok(user);
            else
                return NotFound(new ErrorMsg($"Usuario con id[{id}] no encontrado",ErrorCodesEnum.NotFound));
        }

        // POST api/Users/login
        [HttpPost("login")]
        [ProducesResponseType(typeof(Usuario), 200)]
        [ProducesResponseType(typeof(ErrorMsg), 404)]
        public IActionResult Login(string username, string password)
        {
            var user = _userRepository.GetUsuario(username, password);
            if (user != null)
                return Ok(user);
            else
                return NotFound(new ErrorMsg("Datos de login erroneos",ErrorCodesEnum.NotFound));
        }

        // POST api/Users
        [HttpPost("")]
        [ProducesResponseType(typeof(Usuario), 201)]
        [ProducesResponseType(typeof(ErrorMsg), 400)]
        [ProducesResponseType(typeof(ErrorMsg), 409)]
        public IActionResult NewUser([FromBody] UsuarioCreate newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorMsg("No se ha proporcionado un usuario valido", ErrorCodesEnum.BadRequest));

            var userData = new Usuario
            {
                Username = newUser.Username,
                Password = newUser.Password,
                Mail = newUser.Mail,
                Name = newUser.Name,
                ImageUrl = "images/default.jpg"
            };

            if (_userRepository.UserByUsername(newUser.Username) != null)
                return StatusCode(StatusCodes.Status409Conflict,
                    new ErrorMsg($"El usuario [{newUser.Username}] ya existe", ErrorCodesEnum.NameConflict));

            try
            {
                var result = _userRepository.NewUsuario(userData);
                _userRepository.Save();
                return Created($"{ConfigurationManager.Instance.HostUrl}/api/Users/{result.Id}", result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(new ErrorMsg("No se ha proporcionado un usuario valido", ErrorCodesEnum.BadRequest));
            }
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Usuario), 201)]
        [ProducesResponseType(typeof(ErrorMsg), 400)]
        [ProducesResponseType(typeof(ErrorMsg), 404)]
        public IActionResult UpdateUser(int id, [FromBody] UsuarioCreate newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorMsg("No se ha proporcionado un usuario valido", ErrorCodesEnum.BadRequest));

            var oldUser = _userRepository.GetUsuario(id);
            if(oldUser == null)
                return NotFound(new ErrorMsg($"Usuario con id[{id}] no encontrado", ErrorCodesEnum.NotFound));

            oldUser.Mail = newUser.Mail;
            oldUser.Password = newUser.Password;
            oldUser.Name = newUser.Name;

            try
            {
                _userRepository.ModifyUser(oldUser);
                _userRepository.Save();
                return Created($"{ConfigurationManager.Instance.HostUrl}/api/Users/{oldUser.Id}", oldUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(new ErrorMsg("No se ha proporcionado un usuario valido", ErrorCodesEnum.BadRequest));
            }
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMsg), 404)]
        public IActionResult DeleteUser(int id)
        {
            if (_userRepository.DeleteUser(id))
            {
                _userRepository.Save();
                return Ok(new { Msg = $"Usuario [{id}] borrado" });
            }
            else
                return NotFound(new ErrorMsg($"Usuario [{id}] no se ha encontrado", ErrorCodesEnum.NotFound));
        }

        // PUT api/Users/5/photo
        [HttpPut("{id}/photo")]
        [ProducesResponseType(typeof(Usuario), 201)]
        [ProducesResponseType(typeof(ErrorMsg), 400)]
        [ProducesResponseType(typeof(ErrorMsg), 404)]
        public IActionResult UpdateUserPhoto(int id, [FromBody] string base64Photo)
        {
            if (String.IsNullOrEmpty(base64Photo))
                return BadRequest(new ErrorMsg("No se ha proporcionado una foto valida", ErrorCodesEnum.BadRequest));

            var oldUser = _userRepository.GetUsuario(id);
            if (oldUser == null)
                return NotFound(new ErrorMsg($"Usuario con id[{id}] no encontrado", ErrorCodesEnum.NotFound));

            try
            {
                oldUser.ImageUrl = SaveImage(base64Photo).Substring(8);
                _userRepository.ModifyUser(oldUser);
                _userRepository.Save();
                return Created($"{ConfigurationManager.Instance.HostUrl}/api/Users/{oldUser.Id}", oldUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(new ErrorMsg("No se ha proporcionado una foto valida", ErrorCodesEnum.BadRequest));
            }
        }

        private string SaveImage(string base64Image)
        {
            var fileRoute = $"wwwroot/images/{Guid.NewGuid().ToString()}";

            byte[] imageBytes = Convert.FromBase64String(base64Image);

            string extension = DetermineExtension(imageBytes.Take(8).Select(x => (int)x));

            fileRoute += "." + extension; 

            System.IO.File.WriteAllBytes(fileRoute, imageBytes);

            return fileRoute;
        }

        ///<seealso cref="https://www.brainyquote.com/quotes/edsger_dijkstra_204329"/> 
        private string DetermineExtension(IEnumerable<int> array)
        {
            var listtest = array.ToArray();
            //Esto con OOP es una gochada
            var list = ListModule.OfSeq(listtest);
            return Magic.ImageUtils.checkMagicNumbers(list);
        }
    }
}