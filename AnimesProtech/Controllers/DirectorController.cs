using Microsoft.AspNetCore.Mvc;
using AnimesProtech.DTO.DirectorDTO;
using AnimesProtech.MANAGER.Interfaces;

namespace AnimesProtech.Controllers
{
    [ApiController]
    [Route("Director")]
    public class DirectorController : ControllerBase
    {
        private readonly ILogger<AnimeController> _logger;
        private readonly IDirectorManager _directorManager;

        public DirectorController(ILogger<AnimeController> logger, IDirectorManager directorManager)
        {
            _logger = logger;
            _directorManager = directorManager;
        }

        [Route("HealtCheck")]
        [HttpGet]
        public JsonResult HealthCheck()
        {
            return new JsonResult("I am alive and working!");
        }

        [Route("GetDirectors")]
        [HttpGet]
        public IActionResult GetDirectors(int page = 1)
        {
            var result = _directorManager.GetDirectors(page);
            return Ok(result);
        }

        [Route("GetDirectorsById/{idDirector}")]
        [HttpGet]
        public IActionResult GetDirectorById(long idDirector)
        {
            var result = _directorManager.GetDirectorById(idDirector);
            return Ok(result);
        }

        [Route("GetDirectorsByName")]
        [HttpGet]
        public IActionResult GetDirectorById(string nome, int page = 1)
        {
            var result = _directorManager.GetDirectorByName(nome, page);
            return Ok(result);
        }

        [Route("AddDirector")]
        [HttpPost]
        public IActionResult AddDirector(RegisterDirectorDTO request)
        {
            var response = _directorManager.Register(request);
            return Created("Diretor cadastrado com sucesso!",response);
        }

        [Route("PutDirector")]
        [HttpPut]
        public IActionResult PutDirector(UpdateDirectorDTO request)
        {
            var response = _directorManager.Update(request);
            return Ok(response);
        }

        [Route("RemoveDirector/{idDirector}")]
        [HttpPatch]
        public IActionResult RemoveDirector(long idDirector)
        {
            var result = _directorManager.Delete(idDirector);
            return NoContent();
        }
    }
}