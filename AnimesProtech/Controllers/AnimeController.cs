using AnimesProtech.DTO.AnimesDTO;
using AnimesProtech.MANAGER.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimesProtech.Controllers
{
    [ApiController]
    [Route("Animes")]
    public class AnimeController : ControllerBase
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
            var result = _animeManager.GetAnimeById(idAnime);
            return Ok(result);
        }

        [Route("GetAnimeByDirector/{idDirector}")]
        [HttpGet]
        public IActionResult GetAnimeByDirector(int idDirector, int page = 1)
        {
            var result = _animeManager.GetAnimesByDirector(idDirector, page);
            return Ok(result);
        }

        [Route("GetAnimeByName")]
        [HttpGet]
        public IActionResult GetAnimeByName(string name, int page = 1)
        {
            var result = _animeManager.GetAnimesByTitle(name, page);
            return Ok(result);
        }

        [Route("GetAnimeByKeyWord")]
        [HttpGet]
        public IActionResult GetAnimeByKeyWord(string name, int page = 1)
        {
            var result = _animeManager.GetAnimesByKeyWord(name, page);
            return Ok(result);
        }

        [Route("AddAnime")]
        [HttpPost]
        public IActionResult AddAnime(RegisterAnimeDTO request)
        {
            var result = _animeManager.Register(request.Name, request.Description, request.IdDirector);
            return Created("Anime cadastrado com sucesso!", result);
        }

        [Route("PutAnime")]
        [HttpPut]
        public IActionResult PutAnime(UpdateAnimeDTO request)
        {
            var result = _animeManager.Update(request);
            return Ok(result);
        }

        [Route("RemoveAnime/{idAnime}")]
        [HttpPatch]
        public IActionResult RemoveAnime(long idAnime)
        {
            var result = _animeManager.Delete(idAnime);
            return NoContent();
        }
    }
}