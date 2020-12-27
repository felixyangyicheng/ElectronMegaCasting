using ApiMegaCasting.Repository.Signature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeContratsController : ControllerBase
    {
        private readonly ITypeContratRepository _typeContratRepository;
        public TypeContratsController(ITypeContratRepository typeContratRepository)
        {
            this._typeContratRepository = typeContratRepository;
        }
        #region Liste des types
        [HttpGet]
        public  async Task<ActionResult> GetTypeContrats()
        {
            try
            {
                return Ok(await _typeContratRepository.GetTypeContrats());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Type par id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TypeContrat>> GetTypeContrat(int id)
        {
            try
            {
                var result = await _typeContratRepository.GetTypeContrat(id);
                if (result==null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Ajouter
        [HttpPost]
        public  async Task<ActionResult<TypeContrat>> CreateTypeContrat(TypeContrat typeContrat)
        {
            try
            {
                if (typeContrat == null) return BadRequest();
                //Need to verify and add GetTypeContratByName in its Repository
                var createdType = await _typeContratRepository.AddTypeContrat(typeContrat);
                return CreatedAtAction(nameof(GetTypeContrat), new { id = createdType.Id }, createdType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Mettre à jour
        [HttpPut()]
        public  async Task<ActionResult<TypeContrat>> UpdateTypeContrat(int id, TypeContrat typeContrat)
        {
            try
            {
                if(id!=typeContrat.Id) return BadRequest("Id typecontrat ne correspond pas ");
                //Need to verify and add GetTypeContratByName in its Repository
                var tToUpdate = await _typeContratRepository.GetTypeContrat(id);
                if(tToUpdate==null) return NotFound($"typeContrat avec Id={id} n'a pas été trouvé");
                return await _typeContratRepository.UpdateTypeContrat(typeContrat);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Supprimer
        [HttpDelete("{id:int}")]
        public  async Task<ActionResult<TypeContrat>> DeleteTypeContrat(int id)
        {
            try
            {
                var tToDelete = await _typeContratRepository.GetTypeContrat(id);
                if (tToDelete==null)
                {
                    return NotFound($"TypeContrat avec Id={id} n'a pas été trouvé");
                }
                return await _typeContratRepository.DeleteTypeContrat(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
               "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
    }
}
