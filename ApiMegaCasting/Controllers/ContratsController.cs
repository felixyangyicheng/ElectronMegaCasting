using ApiMegaCasting.Repository.Signature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMegaCasting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratsController : ControllerBase
    {
        private readonly IContratRepository _contratRepository;
        public ContratsController(IContratRepository contratRepository)
        {
            this._contratRepository = contratRepository;
        }
        // GET: api/<ContratsController>
        [HttpGet]
        public async Task<ActionResult> GetContrats()
        {
            try
            {
                return Ok(await _contratRepository.GetContrats());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }

        // GET api/<ContratsController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Contrat>> GetContrat(int id)
        {
            try
            {
                var result = await _contratRepository.GetContrat(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }

        // POST api/<ContratsController>
        [HttpPost]
        public async Task<ActionResult<Contrat>> CreateContrat(Contrat contrat)
        {
            try
            {
                if (contrat == null)
                {
                    return BadRequest();
                }
                var c = await _contratRepository.GetContratByCode(contrat.CodeContrat);
                if (c != null)
                {
                    ModelState.AddModelError("Doublon", "Code de contrat existe déjà!");
                    return BadRequest();
                }
                var createdContrat = await _contratRepository.AddContrat(contrat);
                return CreatedAtAction(nameof(GetContrat), new { id = createdContrat.Id }, createdContrat);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }

        // PUT api/<ContratsController>/5
        [HttpPut()]
        public async Task<ActionResult<Contrat>> UpdateContrat(int id, Contrat contrat)
        {
            try
            {
                if (id != contrat.Id)
                {
                    return BadRequest("Id de contrat de correspond pas");
                }
                var ContratToUpdate = await _contratRepository.GetContrat(id);
                if (ContratToUpdate == null)
                {
                    return NotFound($"Contrat avec Id={id} n'a pas été trouvé");
                }
                return await _contratRepository.UpdateContrat(contrat);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }

        // DELETE api/<ContratsController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Contrat>> DeleteContrat(int id)
        {
            try
            {
                var contratToDelete = await _contratRepository.GetContrat(id);
                if (contratToDelete == null)
                {
                    return NotFound($"Contrat avec Id={id} n'a pas été trouvé");
                }
                return await _contratRepository.DeleteContrat(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                      "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        //Api/employees/search/code
        [HttpGet("{Search}")]
        public async Task<ActionResult<IEnumerable<Contrat>>> Search(string code)
        {
            try
            {
                var result = await _contratRepository.Search(code);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                     "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
    }
}
