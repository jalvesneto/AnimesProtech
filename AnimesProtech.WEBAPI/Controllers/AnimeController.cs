using AnimesProtech.DTO.AnimesDTO;
using AnimesProtech.MANAGER.Interfaces;
using AnimesProtech.WEBAPI.Controllers.Base;

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AnimesProtech.WEBAPI.Controllers
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


        /// <summary>
        /// M�todo para verificar a atividade da API.
        /// </summary>
        /// <returns></returns>
        [Route("HealtCheck")]
        [HttpGet]
        public JsonResult HealthCheck()
        {
            return new JsonResult("I am alive and working!");
        }

        /// <summary>
        /// Retorna animes sem nenhuma restri��o, pela ordem de cadastro.
        /// Possui pagina��o, retornando apenas 10 por vez. Par�metro page � 
        /// opcional e por padr�o, retorna a primeira p�gina.
        /// </summary> 
        /// <param name="page"></param>
        /// <returns></returns>
        [Route("GetAnimes")]
        [HttpGet]
        public IActionResult GetAnimes(int page = 1)
        {
            var result = _animeManager.GetAnimes(page);
            return Ok(result);
        }

        /// <summary>
        /// Retorna as informa��es de um Anime em espec�fico, de acordo com seu id.
        /// Par�metro idAnime � obrigat�rio e do tipo long.
        /// </summary>
        /// <param name="idAnime"></param>
        /// <returns></returns>
        [Route("GetAnimeById/{idAnime}")]
        [HttpGet]
        public IActionResult GetAnimeById(long idAnime)
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

        /// <summary>
        /// Retorna lista de animes de acordo com seu diretor.
        /// Possui pagina��o, retornando apenas 10 por vez. Par�metro page � 
        /// opcional e por padr�o, retorna a primeira p�gina. 
        /// o par�metro idDirector � obrigat�rio e representa o id do Diretor.
        /// </summary>
        /// <param name="idDirector"></param>
        /// <param name="page"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Retorna lista de animes de acordo com seu t�tulo.
        /// Possui pagina��o, retornando apenas 10 por vez. Par�metro page � 
        /// opcional e por padr�o, retorna a primeira p�gina. 
        /// O par�metro name, do tipo string representa um termo para buscar entre os t�tulos dos animes.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna lista de animes de acordo com keywords em seu resumo.
        /// Possui pagina��o, retornando apenas 10 por vez. Par�metro page � 
        /// opcional e por padr�o, retorna a primeira p�gina. 
        /// o par�metro name, do tipo string representa um termo para buscar 
        /// nos resumos dos animes.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <returns></returns>
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

        /// <summary>
        /// M�todo para adicionar um anime.
        /// Par�metro obrigat�rio do tipo RegisterAnimeDTO
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("AddAnime")]
        [HttpPost]
        public IActionResult AddAnime(RegisterAnimeDTO request)
        {
            try
            {
                Validator.ValidateObject(request, new ValidationContext(request), true);
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

        /// <summary>
        /// M�todo para editar as informa��es um anime.
        /// Par�metro obrigat�rio do tipo UpdateAnimeDTO
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("PutAnime")]
        [HttpPut]
        public IActionResult PutAnime(UpdateAnimeDTO request)
        {
            try
            {
                Validator.ValidateObject(request, new ValidationContext(request), true);
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

        /// <summary>
        /// M�todo para realizar a exclus�o l�gica de animes. 
        /// Par�metro obrigat�rio idAnime do tipo long.
        /// </summary>
        /// <param name="idAnime"></param>
        /// <returns></returns>
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