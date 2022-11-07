using AnimesProtech.DTO.DirectorDTO;
using AnimesProtech.MANAGER.Interfaces;
using AnimesProtech.WEBAPI.Controllers.Base;

using Microsoft.AspNetCore.Mvc;

namespace AnimesProtech.Controllers
{
    [ApiController]
    [Route("Director")]
    public class DirectorController : BaseController
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
            try
            {
                var result = _directorManager.GetDirectors(page);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [Route("GetDirectorsById/{idDirector}")]
        [HttpGet]
        public IActionResult GetDirectorById(long idDirector)
        {
            try
            {
                var result = _directorManager.GetDirectorById(idDirector);
                return Ok(result);
            }
            catch (OperationCanceledException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [Route("GetDirectorsByName")]
        [HttpGet]
        public IActionResult GetDirectorByName(string nome, int page = 1)
        {
            try
            { 
                var result = _directorManager.GetDirectorByName(nome, page);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [Route("AddDirector")]
        [HttpPost]
        public IActionResult AddDirector(RegisterDirectorDTO request)
        {
            try
            {
                var response = _directorManager.Register(request);
                return Created("Diretor cadastrado com sucesso!",response);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [Route("PutDirector")]
        [HttpPut]
        public IActionResult PutDirector(UpdateDirectorDTO request)
        {
            try
            {
                var response = _directorManager.Update(request);
                return Ok(response);
            }
            catch (OperationCanceledException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [Route("RemoveDirector/{idDirector}")]
        [HttpPatch]
        public IActionResult RemoveDirector(long idDirector)
        {
            try
            {
                var result = _directorManager.Delete(idDirector);
                return NoContent();
            }
            catch (OperationCanceledException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
    }
}