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
    public class PartenairesController : ControllerBase
    {
        private readonly IPartenaireRepository _partenaireRepository;
        public PartenairesController(IPartenaireRepository partenaireRepository)
        {
            this._partenaireRepository = partenaireRepository;
        }
        #region Liste des partenaires
        [HttpGet]
        public async Task<ActionResult> GetPartenaires()
        {
            try
            {
                return Ok(await _partenaireRepository.GetPartenaires());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Liste des partenaires par libelle
        //Api/Partenaires/name/john
        [HttpGet("{name}")]
        public  async Task<ActionResult<IEnumerable<Partenaire>>> SearchName(string libelle)
        {
            try
            {
                var result = await _partenaireRepository.SearchByName(libelle);
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
        #region Liste des partenaires par adresse
        //Api/Partenaires/address/john
        [HttpGet("{address}")]
        // api/Partenaires/address?adresse=john
        public async Task<ActionResult<IEnumerable<Partenaire>>> SearchAddress(string adresse)
        {
            try
            {
                var result = await _partenaireRepository.SearchByAddress(adresse);
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
        #region partenaire par id
        [HttpGet("{id:int}")]
        public  async Task<ActionResult<Partenaire>> GetPartenaire(int id)
        {
            try
            {
                var result = await _partenaireRepository.GetPartenaire(id);
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
        #region partenaire par email
        [HttpGet("{email:string}")]
        public async Task<ActionResult<Partenaire>> GetPartenaireByEmail(string email)
        {
            try
            {
                var result = await _partenaireRepository.GetPartenaireByEmail(email);
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
        #region partenaire par libellé
        [HttpGet("{libelle:string}")]
        public async Task<ActionResult<Partenaire>> GetPartenaireByName(string libelle)
        {
            try
            {
                var result = await _partenaireRepository.GetPartenaireByName(libelle);
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

        #region partenaire par login
        #endregion

        #region Ajouter
        [HttpPost]
        public  async Task<ActionResult<Partenaire>> CreatePartenaire(Partenaire partenaire)
        {
            try
            {
                if (partenaire == null) return BadRequest();
                var pEmail = await _partenaireRepository.GetPartenaireByEmail(partenaire.Email);
                var pLogin = await _partenaireRepository.GetPartenaireByLogin(partenaire.Login);
                if (pEmail != null)
                {
                    ModelState.AddModelError("Email", "Email existe déjà");
                    return BadRequest(ModelState);
                }
                if (pLogin != null)
                {
                    ModelState.AddModelError("Login", "Login existe déjà");
                    return BadRequest(ModelState);
                }
                var createdPartenaire = await _partenaireRepository.AddPartenaire(partenaire);
                return CreatedAtAction(nameof(GetPartenaire), new { id = createdPartenaire.Id }, createdPartenaire);
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
        public async Task<ActionResult<Partenaire>> UpdatePartenaire(int id, Partenaire partenaire)
        {
            try
            {
                if (id != partenaire.Id)
                    return BadRequest("Id Partenaire ne correspond pas");
                var pEmail = await _partenaireRepository.GetPartenaireByEmail(partenaire.Email);
                var pLogin = await _partenaireRepository.GetPartenaireByLogin(partenaire.Login);
                if (pEmail != null)
                {
                    ModelState.AddModelError("Email", "Email existe déjà");
                    return BadRequest(ModelState);
                }
                if (pLogin != null)
                {
                    ModelState.AddModelError("Login", "Login existe déjà");
                    return BadRequest(ModelState);
                }

                var pToUpdate = await _partenaireRepository.GetPartenaire(id);
                if(pToUpdate==null) return NotFound($"Partenaire avec Id={id} n'a pas été trouvé");
                return await _partenaireRepository.UpdatePartenaire(partenaire);
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
        public  async Task<ActionResult<Partenaire>> DeletePartenaire(int id)
        {
            try
            {
                var PtoDelete = await _partenaireRepository.GetPartenaire(id);
                if (PtoDelete==null)
                {
                    return NotFound($"Partenaire avec Id={id} n'a pas été trouvé");

                }
                return await _partenaireRepository.DeletePartenaire(id);
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
