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
    public class OffresController : ControllerBase
    {
        private readonly IOffreRepository _offreRepository;
        public OffresController(IOffreRepository offreRepository)
        {
            this._offreRepository = offreRepository;
        }

        #region Liste des offres
        [HttpGet]
        public async Task<ActionResult> GetOffres()
        {
            try
            {
                return Ok(await _offreRepository.GetOffres());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion

        #region Liste des offres par intitulé
        [HttpGet("{title}")]
        // api/employees/title?intitule=john
        public async Task<ActionResult<IEnumerable<Offre>>> SearchTitle(string intitule)
        {
            try
            {
                var result = await _offreRepository.SearchByTitle(intitule);
                if (result.Any())
                    return Ok(result);
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Liste des offres par localisation
        [HttpGet("{location}")]
        // api/employees/location?localisation=john
        public async Task<ActionResult<IEnumerable<Offre>>> SearchLocation(string localisation)
        {
            try
            {
                var result = await _offreRepository.SearchByTitle(localisation);
                if (result.Any())
                    return Ok(result);
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Offre par id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Offre>> GetOffre(int id)
        {
            try
            {
                var result = await _offreRepository.GetOffre(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Offre par code
        [HttpGet("{code}")]
        public async Task<ActionResult<Offre>> GetOffreByCode(string code)
        {
            try
            {
                var result = await _offreRepository.GetOffreByCode(code);
                if (result == null) return NotFound();
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
        public async Task<ActionResult<Offre>> CreateOffre(Offre offre)
        {
            try
            {
                if (offre == null)
                {
                    return BadRequest();

                }
                var oCode = await _offreRepository.GetOffreByCode(offre.CodeOffre);
                if (oCode != null)
                {
                    ModelState.AddModelError("Code", "Code existe déjà");
                    return BadRequest(ModelState);

                }
                var createdOffre = await _offreRepository.AddOffre(offre);
                return CreatedAtAction(nameof(GetOffre), new { id = createdOffre.Id }, createdOffre);
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
        public async Task<ActionResult<Offre>> UpdateOffre(int id, Offre offre)
        {
            try
            {
                if (id != offre.Id)
                    return BadRequest("Id Offre ne correspond pas");
                var oToUpdate = await _offreRepository.GetOffre(id);
                if (oToUpdate == null)
                {
                    return NotFound($"Offre avec Id={id} n'a pas été trouvée");
                }
                return await _offreRepository.UpdateOffre(offre);
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
        public async Task<ActionResult<Offre>> DeleteOffre(int id)
        {
            try
            {
                var oToDelete = await _offreRepository.GetOffre(id);
                if (oToDelete == null)
                    return NotFound($"Offre avec Id={id} n'a pas été trouvée");
                return await _offreRepository.DeleteOffre(id);
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
