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
        public JsonResult GetDirectors()
        {
            return new JsonResult("I am alive and working!");
        }

        [Route("AddDirector")]
        [HttpPost]
        public IActionResult AddDirector(RegisterDirectorDTO request)
        {
            var response = _directorManager.Register(request);
            return Ok(response);
        }

        [Route("PutDirector")]
        [HttpPut]
        public IActionResult PutDirector(UpdateDirectorDTO request)
        {
            return Ok(request);
        }

        [Route("RemoveDirector/{idDirector}")]
        [HttpPatch]
        public JsonResult RemoveDirector(long idDirector)
        {
            return new JsonResult(idDirector);
        }
    }
}