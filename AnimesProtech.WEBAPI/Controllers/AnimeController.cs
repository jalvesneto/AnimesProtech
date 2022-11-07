using AnimesProtech.DTO.AnimesDTO;
using AnimesProtech.MANAGER.Interfaces;
using AnimesProtech.WEBAPI.Controllers.Base;

using Microsoft.AspNetCore.Mvc;

namespace AnimesProtech.Controllers
{
    [ApiController]
    [Route("Animes")]
    public class AnimeController : BaseController
    {
        private readonly ILogger<AnimeController> _logger;

        private readonly IAnimeManager _animeManager;

        public AnimeController(ILogger<AnimeController> logger, IAnimeManager animeManager)
        {
            _logger = logger;
            _animeManager = animeManager;
        }

        [Route("HealtCheck")]
        [HttpGet]
        public JsonResult HealthCheck()
        {
            return new JsonResult("I am alive and working!");
        }

        [Route("GetAnimes")]
        [HttpGet]
        public IActionResult GetAnimes(int page = 1)
        {
            var result = _animeManager.GetAnimes(page);
            return Ok(result);
        }

        [Route("GetAnimeById/{idAnime}")]
        [HttpGet]
        public IActionResult GetAnimeById(int idAnime)
        {
            try
            {
                var result = _animeManager.GetAnimeById(idAnime);
                return Ok(result);
            }
            catch (OperationCanceledException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [Route("GetAnimeByDirector/{idDirector}")]
        [HttpGet]
        public IActionResult GetAnimeByDirector(int idDirector, int page = 1)
        {
            try
            {
                var result = _animeManager.GetAnimesByDirector(idDirector, page);
                return Ok(result);
            }
            catch (OperationCanceledException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [Route("GetAnimeByName")]
        [HttpGet]
        public IActionResult GetAnimeByName(string name, int page = 1)
        {
            try
            {
                var result = _animeManager.GetAnimesByTitle(name, page);
                return Ok(result);
            }
            catch (OperationCanceledException)
            {
                return NoContent();
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [Route("GetAnimeByKeyWord")]
        [HttpGet]
        public IActionResult GetAnimeByKeyWord(string name, int page = 1)
        {
            try
            {
                var result = _animeManager.GetAnimesByKeyWord(name, page);
                return Ok(result);
            }
            catch (OperationCanceledException)
            {
                return NoContent();
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [Route("AddAnime")]
        [HttpPost]
        public IActionResult AddAnime(RegisterAnimeDTO request)
        {
            try
            {
                var result = _animeManager.Register(request);
                return Created("Anime cadastrado com sucesso!", result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [Route("PutAnime")]
        [HttpPut]
        public IActionResult PutAnime(UpdateAnimeDTO request)
        {
            try
            {
                var result = _animeManager.Update(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }


        [Route("RemoveAnime/{idAnime}")]
        [HttpPatch]
        public IActionResult RemoveAnime(long idAnime)
        {
            try
            {
                var result = _animeManager.Delete(idAnime);
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