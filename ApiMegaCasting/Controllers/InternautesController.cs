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
    public class InternautesController : ControllerBase
    {
        private readonly IInternauteRepository _internauteRepository;
        public InternautesController(IInternauteRepository internauteRepository)
        {
            this._internauteRepository = internauteRepository;
        }

        #region Liste des internautes
        [HttpGet]
        public async Task<ActionResult> GetInternautes()
        {
            try
            {
                return Ok(await _internauteRepository.GetInternautes());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Liste des internautes par Login
        //[HttpGet("{search}/{name}/{gender?}")]
        //Api/employees/search/john/Mr
        [HttpGet("{search}")]
        // api/employees/search?name=john
        // api/employees/search?name=john&gender=Mr
        // api/employees/search?gender=Mr
        public async Task<ActionResult<IEnumerable<Internaute>>> Search(string name, Civilite? civilite)
        {
            try
            {
                var result = await _internauteRepository.Search(name, civilite);
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
        #region Internaute par Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Internaute>> GetInternaute(int id)
        {
            try
            {
                var result = await _internauteRepository.GetInternaute(id);
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
        #region Internaute par Login
        [HttpGet("{login:string}")]
        public async Task<ActionResult<Internaute>> GetInternauteByName(string login)
        {
            try
            {
                var result = await _internauteRepository.GetInternauteByLogin(login);
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
        #region Internaute par Email
        [HttpGet("{email:string}")]
        public async Task<ActionResult<Internaute>> GetInternauteByEmail(string email)
        {
            try
            {
                var result = await _internauteRepository.GetInternauteByLogin(email);
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
        #region Ajouter internaute
        [HttpPost]
        public async Task<ActionResult<Internaute>> CreateInternaute(Internaute internaute)
        {
            try
            {
                if (internaute==null)
                {
                    return BadRequest();
                }
                var iEmail = await _internauteRepository.GetInternauteByEmail(internaute.Email);
                var iLogin = await _internauteRepository.GetInternauteByLogin(internaute.Login);

                if (iEmail!=null)
                {
                    ModelState.AddModelError("Email", "Email existe déjà");
                    return BadRequest(ModelState);
                }
                if(iLogin != null)
                {
                    ModelState.AddModelError("Login", "Login existe déjà");
                    return BadRequest(ModelState);
                }
                var createdInternaute = await _internauteRepository.AddInternaute(internaute);
                return CreatedAtAction(nameof(GetInternaute), new { id = createdInternaute.Id }, createdInternaute);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Mettre à jour internaute
        [HttpPut()]
        public async Task<ActionResult<Internaute>> UpdateInternaute(int id, Internaute internaute)
        {
            try
            {
                if (id != internaute.Id)
                    return BadRequest("Id Internaute ne correspond pas ");

                var iEmail = await _internauteRepository.GetInternauteByEmail(internaute.Email);
                var iLogin = await _internauteRepository.GetInternauteByLogin(internaute.Login);

                if (iEmail != null)
                {
                    ModelState.AddModelError("Email", "Email existe déjà");
                    return BadRequest(ModelState);
                }
                if (iLogin != null)
                {
                    ModelState.AddModelError("Login", "Login existe déjà");
                    return BadRequest(ModelState);
                }
                
                var iToUpdate = await _internauteRepository 
                    .GetInternaute(id);
                if (iToUpdate==null)
                {
                    return NotFound($"Internaute avec Id={id} n'a pas été trouvé");
                }
                return await _internauteRepository.UpdateInternaute(internaute);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Supprimer internaute
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Internaute>> DeleteInternaute(int id)
        {
            try
            {
                var iToDelete = await _internauteRepository.GetInternaute(id);
                if (iToDelete==null)
                {
                    return NotFound($"Internaute avec Id={id} n'a pas été trouvé");
                }
                return await _internauteRepository.DeleteInternaute(id);
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
