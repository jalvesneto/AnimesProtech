using AnimesProtech.DTO.DirectorDTO;
using AnimesProtech.MANAGER.Interfaces;
using AnimesProtech.WEBAPI.Controllers.Base;

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AnimesProtech.WEBAPI.Controllers
{
    [ApiController]
    [Route("Director")]
    public class DirectorController : BaseController
    {
        private readonly ILogger<DirectorController> _logger;
        private readonly IDirectorManager _directorManager;

        public DirectorController(ILogger<DirectorController> logger, IDirectorManager directorManager)
        {
            _logger = logger;
            _directorManager = directorManager;
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
        /// Retorna diretores sem nenhuma restrição, pela ordem de cadastro.
        /// Possui paginação, retornando apenas 10 por vez. Parâmetro page é 
        /// opcional e por padrão, retorna a primeira página.
        /// </summary> 
        /// <param name="page"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna as informações de um Diretor em específico, de acordo com seu id.
        /// Parâmetro idDirector é obrigatório e do tipo long.
        /// </summary>
        /// <param name="idDirector"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna lista de diretores de acordo com seu nome.
        /// Possui paginação, retornando apenas 10 por vez. Parâmetro page é 
        /// opcional e por padrão, retorna a primeira página. 
        /// O parâmetro nome, do tipo string representa um termo para buscar entre os nomes dos diretores.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="page"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método para adicionar um diretor.
        /// Parâmetro obrigatório do tipo RegisterDirectorDTO
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("AddDirector")]
        [HttpPost]
        public IActionResult AddDirector(RegisterDirectorDTO request)
        {
            try
            {
                Validator.ValidateObject(request, new ValidationContext(request), true);
                var response = _directorManager.Register(request);
                return Created("Diretor cadastrado com sucesso!",response);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        /// <summary>
        /// Método para editar as informações de um diretor.
        /// Parâmetro obrigatório do tipo UpdateDirectorDTO
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método para realizar a exclusão lógica de diretores. 
        /// Parâmetro obrigatório idDirector do tipo long.
        /// </summary>
        /// <param name="idDirector"></param>
        /// <returns></returns>
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