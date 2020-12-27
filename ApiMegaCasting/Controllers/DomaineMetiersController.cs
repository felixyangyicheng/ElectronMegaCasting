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
    public class DomaineMetiersController : ControllerBase
    {
        private readonly IDomaineMetierRepository _domaineMetierRepository;
        public DomaineMetiersController(IDomaineMetierRepository domaineMetierRepository)
        {
            this._domaineMetierRepository = domaineMetierRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDomaineMetiers()
        {
            try
            {
                return Ok(await _domaineMetierRepository.GetDomaineMetiers());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }

        }

        [HttpGet("{id:int}")]
        // id map with  GetEmployee(int id) below
        public async Task<ActionResult<DomaineMetier>> GetDomaineMetier(int id)
        {
            try
            {
                var result = await _domaineMetierRepository.GetDomaineMetier(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        [HttpGet("{libelle:string}")]
        // id map with  GetEmployee(int id) below
        public async Task<ActionResult<DomaineMetier>> GetDomaineMetierByName(string libelle)
        {
            try
            {
                var result = await _domaineMetierRepository.GetDomaineMetierByName(libelle);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DomaineMetier>> CreateDomaineMetier(DomaineMetier domaineMetier)
        {
            try
            {
                if (domaineMetier == null)
                {
                    return BadRequest();
                }

                // Add custom model validation error
                var dm = await _domaineMetierRepository.GetDomaineMetierByName(domaineMetier.Libelle);

                if (dm != null)
                {
                    ModelState.AddModelError("domaineMetier", "Ce libellé existe déjà");
                    return BadRequest(ModelState);
                }

                var createdDomaine = await _domaineMetierRepository.AddDomaineMetier(domaineMetier);

                return CreatedAtAction(nameof(GetDomaineMetier), new { id = createdDomaine.Id },
                    createdDomaine);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        [HttpPut()]
        public async Task<ActionResult<DomaineMetier>> UpdateDomaineMetier(int id, DomaineMetier domaineMetier)
        {
            try
            {
                if (id!=domaineMetier.Id)
                {
                    return BadRequest("DomaineMetier Id ne correspond pas");
                }
                var dmToUpdate = await _domaineMetierRepository.GetDomaineMetier(id);
                if (dmToUpdate == null)
                    return NotFound($"DomaineMetier avec Id={id} n'a pas été trouvé");
                return await _domaineMetierRepository.UpdateDomaineMetier(domaineMetier);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<DomaineMetier>> DeleteDomaineMetier(int id)
        {
            try
            {
                var dmToDelete = await _domaineMetierRepository.GetDomaineMetier(id);
                if (dmToDelete == null) return NotFound($"Domaine avec Id={id} n'a pas été trouvé");
                return await _domaineMetierRepository.DeleteDomaineMetier(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }

        

    }
}
