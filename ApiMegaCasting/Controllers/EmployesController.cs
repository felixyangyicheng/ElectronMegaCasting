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
    public class EmployesController : ControllerBase
    {

        private readonly IEmployeRepository _employeRepository;
        public EmployesController(IEmployeRepository employeRepository)
        {
            this._employeRepository = employeRepository;
        }

        #region Liste de tous les employés
        [HttpGet]

        public async Task<ActionResult> GetEmployes()
        {
            try
            {
                return Ok(await _employeRepository.GetEmployes());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Employé par Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employe>> GetEmploye(int id)
        {
            try
            {
                var result = await _employeRepository.GetEmploye(id);
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
        #region Employé par Login
        [HttpGet("{login}")]
        public async Task<ActionResult<Employe>> GetEmployeByLogin(string login)
        {
            try
            {
                var result = await _employeRepository.GetEmployeByLogin(login);
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
        #region Mettre à jour employé
        [HttpPut]
        public async Task<ActionResult<Employe>> UpdateEmployee(int id, Employe employe)
        {
            try
            {
                if (id != employe.Id)
                {
                    return BadRequest("Employe Id ne correspond pas");
                }
                var eToUpdate = await _employeRepository.GetEmploye(id);
                if (eToUpdate == null)
                {
                    return NotFound($"Employe avec Id={id} n'a pas été trouvé");
                }
                return await _employeRepository.UpdateEmploye(employe);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Créer employé
        [HttpPost]
        public async Task<ActionResult<Employe>> CreateEmploye(Employe employe)
        {
            try
            {
                if (employe == null)
                {
                    return BadRequest();
                }
                var emp = await _employeRepository.GetEmployeByLogin(employe.Login);
                if (emp != null)
                {
                    ModelState.AddModelError("Employe", "Employe login existe déjà.");
                    return BadRequest(ModelState);
                }
                var createdEmploye = await _employeRepository.AddEmploye(employe);
                return CreatedAtAction(nameof(GetEmploye), new { id = createdEmploye.Id }, createdEmploye);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Supprimer Employé
        [HttpDelete("{id:int}")]

        public async Task<ActionResult<Employe>> DeleteEmploye(int id)
        {
            try
            {
                var employeToDelete = await _employeRepository.GetEmploye(id);
                if (employeToDelete == null)
                {
                    return NotFound($"Employe avec Id={id} n'a pas été trouvé");
                }
                return await _employeRepository.DeleteEmploye(id);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Rechercher employé
        [HttpGet("{search}")]

        public async Task<ActionResult<IEnumerable<Employe>>> Search(string nom, Civilite? civilite)
        {
            try
            {
                var result = await _employeRepository.Search(nom, civilite);
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
    }
}
