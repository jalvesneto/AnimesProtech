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
        /// Método para verificar a atividade da API.
        /// </summary>
        /// <returns></returns>
        [Route("HealtCheck")]
        [HttpGet]
        public JsonResult HealthCheck()
        {
            return new JsonResult("I am alive and working!");
        }

        /// <summary>
        /// Retorna animes sem nenhuma restrição, pela ordem de cadastro.
        /// Possui paginação, retornando apenas 10 por vez. Parâmetro page é 
        /// opcional e por padrão, retorna a primeira página.
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
        /// Retorna as informações de um Anime em específico, de acordo com seu id.
        /// Parâmetro idAnime é obrigatório e do tipo long.
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
        /// Possui paginação, retornando apenas 10 por vez. Parâmetro page é 
        /// opcional e por padrão, retorna a primeira página. 
        /// o parâmetro idDirector é obrigatório e representa o id do Diretor.
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
        /// Retorna lista de animes de acordo com seu título.
        /// Possui paginação, retornando apenas 10 por vez. Parâmetro page é 
        /// opcional e por padrão, retorna a primeira página. 
        /// O parâmetro name, do tipo string representa um termo para buscar entre os títulos dos animes.
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
        /// Possui paginação, retornando apenas 10 por vez. Parâmetro page é 
        /// opcional e por padrão, retorna a primeira página. 
        /// o parâmetro name, do tipo string representa um termo para buscar 
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
        /// Método para adicionar um anime.
        /// Parâmetro obrigatório do tipo RegisterAnimeDTO
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
        /// Método para editar as informações um anime.
        /// Parâmetro obrigatório do tipo UpdateAnimeDTO
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
        /// Método para realizar a exclusão lógica de animes. 
        /// Parâmetro obrigatório idAnime do tipo long.
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