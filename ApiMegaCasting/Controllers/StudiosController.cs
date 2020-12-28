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
    public class StudiosController : ControllerBase
    {
        private readonly IStudioRepository _studioRepository;
        public StudiosController(IStudioRepository studioRepository)
        {
            this._studioRepository = studioRepository;
        }

        #region Liste des studios
        [HttpGet]
        public async Task<ActionResult> GetStudios()
        {
            try
            {
                return Ok(await _studioRepository.GetStudios());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Liste des studios par nom
        //Api/Partenaires/name/john
        [HttpGet("{name}")]

        public async Task<ActionResult<IEnumerable<Studio>>> SearchName(string libelle)
        {
            try
            {
                var result = await _studioRepository.SearchByName(libelle);
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
        #region Liste des studios par adresse
        //Api/Partenaires/address/john
        [HttpGet("{address}")]
        // api/Partenaires/address?adresse=john

        public async Task<ActionResult<IEnumerable<Studio>>> SearchAddress(string adresse)
        {
            try
            {
                var result = await _studioRepository.SearchByAddress(adresse);
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
        #region studio par id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Studio>> GetStudio(int id)
        {
            try
            {
                var result = await _studioRepository.GetStudio(id);
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
        #region studio par email
        [HttpGet("{findemail}")]
        public async Task<ActionResult<Studio>> GetStudioByEmail(string email)
        {
            try
            {
                var result = await _studioRepository.GetStudioByEmail(email);
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
        #region studion par libellé
        [HttpGet("{findname}")]
        public async Task<ActionResult<Studio>> GetStudioByName(string libelle)
        {
            try
            {
                var result = await _studioRepository.GetStudioByName(libelle);
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
        public async Task<ActionResult<Studio>> CreateStudio(Studio studio)
        {
            try
            {
                if (studio == null)
                {
                    return BadRequest();
                }
                var sEmail = await _studioRepository.GetStudioByEmail(studio.Email);
                if (sEmail != null)
                {
                    ModelState.AddModelError("Email", "Email existe déjà");
                    return BadRequest(ModelState);
                }
                var createdStudio = await _studioRepository.AddStudio(studio);
                return CreatedAtAction(nameof(GetStudio), new { id = createdStudio.Id }, createdStudio);

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
        public async Task<ActionResult<Studio>> UpdateStudio(int id, Studio studio)
        {
            try
            {
                if (id != studio.Id)
                {
                    return BadRequest("Id Studio  ne correspond pas");
                }
                var sEmail = await _studioRepository.GetStudioByEmail(studio.Email);
                if (sEmail != null)
                {
                    ModelState.AddModelError("Email", "Email existe déjà");
                    return BadRequest(ModelState);
                }
                var sToUpdate = await _studioRepository.GetStudio(id);
                if (sToUpdate == null)
                {
                    return NotFound($"Studio avec Id={id} n'a pas été trouvé");
                }
                return await _studioRepository.UpdateStudio(studio);
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

        public async Task<ActionResult<Studio>> DeleteStudio(int id)
        {
            try
            {
                var sToDelete = await _studioRepository.GetStudio(id);
                if (sToDelete == null)
                {
                    return NotFound($"Studio avec Id={id} n'a pas été trouvé");
                }
                return await _studioRepository.DeleteStudio(id);
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
