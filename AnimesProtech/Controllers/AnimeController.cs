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

        [Route("GetAnime")]
        [HttpGet]
        public JsonResult GetAnime()
        {
            return new JsonResult("I am alive and working!");
        }

        [Route("AddAnime")]
        [HttpPost]
        public IActionResult AddAnime(RegisterAnimeDTO request)
        {
            var result = _animeManager.Register(request.Name, request.Description, request.IdDirector);
            return Ok(result);
        }

        [Route("PutAnime")]
        [HttpPut]
        public IActionResult PutAnime(UpdateAnimeDTO request)
        {
            var result = _animeManager.Update(request.AnimeId, request.Name, request.Description, request.DiretorId);
            return Ok(result);
        }

        [Route("RemoveAnime/{idAnime}")]
        [HttpPatch]
        public JsonResult RemoveAnime(long idAnime)
        {
            return new JsonResult(idAnime);
        }
    }
}