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
    public class MetiersController : ControllerBase
    {
        private readonly IMertierRepository _metierRepository;
        public MetiersController(IMertierRepository mertierRepository)
        {
            this._metierRepository = mertierRepository;
        }

        #region Liste de tous les métiers
        [HttpGet]
        public async Task<ActionResult> GetMetiers()
        {
            try
            {
                return Ok(await _metierRepository.GetMetiers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Liste de métiers par libellé
        [HttpGet("{Search}")]
        public  async Task<ActionResult<IEnumerable<Metier>>> Search (string libelle)
        {
            try
            {
                var result = await _metierRepository.Search(libelle);
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
        #endregion
        #region Métier par id
        [HttpGet("{id:int}")]

        public async Task<ActionResult<Metier>> GetMetier(int id)
        {
            try
            {
                var result = await _metierRepository.GetMetier(id);
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
        #region Métier par libéllé
        [HttpGet("{libelle:string}")]

        public async Task<ActionResult<Metier>> GetMetierByName(string libelle)
        {
            try
            {
                var result = await _metierRepository.GetMetierByName(libelle);
                if (result == null)
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
        public async Task<ActionResult<Metier>> CreateMetier(Metier metier)
        {
            try
            {
                if (metier==null)
                {
                    return BadRequest();
                }

                var m = await _metierRepository.GetMetierByName(metier.Libelle);
                if (m!=null)
                {
                    ModelState.AddModelError("Libelle", "Libellé existe déjà");
                    return BadRequest(ModelState);
                }

                var createdMetier = await _metierRepository.AddMetier(metier);
                return CreatedAtAction(nameof(GetMetier), new { id = createdMetier.Id }, createdMetier);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Mettre à jour
        [HttpPut]
        public  async Task<ActionResult<Metier>> UpdateMetier(int id, Metier metier)
        {
            try
            {
                if (id != metier.Id)
                    return BadRequest("Métier Id ne correspond pas");
                var mToUpdate = await _metierRepository.GetMetier(id);
                if (mToUpdate == null)
                    return NotFound($"Métier avec Id={id} n'a pas été trouvé");
                return await _metierRepository.UpdateMetier(metier);
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
        public async Task<ActionResult<Metier>> DeleteMetier(int id)
        {
            try
            {
                var mtoDelete = await _metierRepository.GetMetier(id);
                if (mtoDelete == null)
                    return NotFound($"Métier avec Id={id} n'a pas été trouvé");
                return await _metierRepository.DeleteMetier(id);
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
