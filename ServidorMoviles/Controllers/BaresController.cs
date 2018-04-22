using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServidorMoviles.Models;
using ServidorMoviles.Models.Form;
using ServidorMoviles.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServidorMoviles.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BaresController : Controller
    {
        private readonly IBaresRepository _baresRepository;

        public BaresController(IBaresRepository repo) => _baresRepository = repo;

        // GET api/Bares
        [ProducesResponseType(typeof(IEnumerable<Bar>), 200)]
        [HttpGet("")]
        public IActionResult GetAllBares() => Ok(_baresRepository.GetBares());

        // GET api/Bares/5
        [ProducesResponseType(typeof(Bar), 200)]
        [ProducesResponseType(typeof(ErrorMsg), 404)]
        [HttpGet("{id}")]
        public IActionResult GetBar(int id)
        {
            var bar = _baresRepository.GetBar(id);
            if (bar != null)
                return Ok(bar);
            else
                return NotFound(new ErrorMsg($"Bar con id[{id}] no encontrado", ErrorCodesEnum.NotFound));
        }

        //GET api/Bares/destacados
        [ProducesResponseType(typeof(IEnumerable<Bar>), 200)]
        [HttpGet("destacados")]
        public IActionResult GetDestacados() => Ok(_baresRepository.GetDestacados());
    }
}
