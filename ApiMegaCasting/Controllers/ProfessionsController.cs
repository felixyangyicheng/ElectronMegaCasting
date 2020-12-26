using ApiMegaCasting.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelMegaCasting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionsController : ControllerBase
    {
        #region Attribut

        private readonly IProfessionRepository _professionRepository;
        #endregion

        #region Constructor

        public ProfessionsController(IProfessionRepository professionRepository)
        {
            this._professionRepository = professionRepository;
        }
        #endregion

        #region GetAllProfessions
        [HttpGet]

        public async Task<ActionResult> GetProfessions()
        {
            try
            {
                return Ok(await _professionRepository.GetProfessions());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur de recherche depuis la base de données");
            }
        }
        #endregion

        #region GetProfessionById
        [HttpGet("{id:int}")]

        public async Task<ActionResult<Profession>> GetProfession(int id)
        {
            try
            {
                var result = await _professionRepository.GetProfession(id);
                if (result == null) return NotFound();
                return result;
               
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Erreur de recherche depuis la base de données");
            }
        }

        #endregion

        #region CreateProfession
        [HttpPost]
        public async Task<ActionResult<Profession>> CreateProfession(Profession profession)
        {
            try
            {
                if (profession==null)
                {
                    return BadRequest();
                }
                var pro = await _professionRepository.GetProfessionByName(profession.ProfessionName);
                if (pro!=null)
                {
                    ModelState.AddModelError("Libellé de profession", "Ce libelle existe déjà!");
                    return BadRequest(ModelState);
                }
                var createdProfession = await _professionRepository
                    .AddProfession(profession);
                return CreatedAtAction(nameof(GetProfession), new { id = createdProfession.ProfessionId }, createdProfession);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Erreur de recherche depuis la base de données");
            }
        }

        #endregion
        #region UpdateProfession

        [HttpPut()]

        public async Task<ActionResult<Profession>> UpdateProfession(int id, Profession profession)
        {
            try
            {
                if (id != profession.ProfessionId)
                    return BadRequest("Id de la profession ne correspond pas");


                var professionToUpdate = await _professionRepository.GetProfession(id);
                if (professionToUpdate==null)
                    return NotFound($"La profession avec Id={id} n'a pas été trouvée");
                return await _professionRepository.UpdateProfession(profession);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur lors de la tentative de mise à jour");
            }
        }
        #endregion
        #region DeleteProfession
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Profession>> DeleteProfession(int id)
        {
            try
            {
                var professionToDelete = await _professionRepository.GetProfession(id);
                if (professionToDelete==null)
                {
                    return NotFound($"La profession avec Id={id} n'a pas été trouvée");

                }
                return await _professionRepository.DeleteProfession(id);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Erreur lors de la tentative de suppression");
            }
        }
        #endregion

        #region SearchProfession
        //Api/Professions/search/john

        [HttpGet("{search}")]
        // api/Professions/search?name=john
        
        public async Task<ActionResult<IEnumerable<Profession>>> Search(string name)
        {
            try
            {
                var result = await _professionRepository.SearchProfession(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Erreur de recherche depuis la base de données");
            }
        }


        #endregion
    }
}
