using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServidorMoviles.Models;
using ServidorMoviles.Models.Form;
using ServidorMoviles.Services;

namespace ServidorMoviles.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TapasController : Controller
    {
        private readonly ITapasRepository _tapasRepository;

        public TapasController(ITapasRepository repo) => _tapasRepository = repo;

        // GET api/Tapaes
        [ProducesResponseType(typeof(IEnumerable<Tapa>), 200)]
        [HttpGet("")]
        public IActionResult GetAllTapaes() => Ok(_tapasRepository.GetTapas());

        // GET api/Tapaes/5
        [ProducesResponseType(typeof(Tapa), 200)]
        [ProducesResponseType(typeof(ErrorMsg), 404)]
        [HttpGet("{id}")]
        public IActionResult GetTapa(int id)
        {
            var tapa = _tapasRepository.GetTapa(id);
            if (tapa != null)
                return Ok(tapa);
            else
                return NotFound(new ErrorMsg($"Tapa con id[{id}] no encontrado", ErrorCodesEnum.NotFound));
        }
    }
}
