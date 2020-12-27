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
    public class GroupeEmployesController : ControllerBase
    {
        private readonly IGroupeEmployeRepository _groupeEmployeRepository;
        public GroupeEmployesController(IGroupeEmployeRepository groupeEmployeRepository)
        {
            this._groupeEmployeRepository = groupeEmployeRepository;
        }

        #region Liste de tous les groupes
        [HttpGet]
        public async Task<ActionResult> GetGroupeEmployes()
        {
            try
            {
                return Ok(await _groupeEmployeRepository.GetGroupeEmployes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                 "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Groupe par id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GroupeEmploye>> GetEmploye(int id)
        {
            try
            {
                var result = await _groupeEmployeRepository.GetGroupeEmploye(id);
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
        #region Groupe par libelle
        public async Task<ActionResult<GroupeEmploye>> GetEmployeByLibelle(string libelle)
        {
            try
            {
                var result = await _groupeEmployeRepository.GetGroupeEmployeByName(libelle);
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
        #region Ajouter un groupe
        [HttpPost]
        public async Task<ActionResult<GroupeEmploye>> CreateGroupeEmploye(GroupeEmploye groupe)
        {
            try
            {
                if (groupe == null)
                {
                    return BadRequest();
                }
                var g = await _groupeEmployeRepository.GetGroupeEmployeByName(groupe.Libelle);

                if (g != null)
                {
                    ModelState.AddModelError("Groupe Employé", "Ce libellé existe déjà");
                    return BadRequest(ModelState);
                }
                var createGroupe = await _groupeEmployeRepository.AddGroupeEmploye(groupe);
                return CreatedAtAction(nameof(GetEmploye), new { id = createGroupe.Id }, createGroupe);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Mettre à jour un groupe
        [HttpPut]
        public async Task<ActionResult<GroupeEmploye>> UpdateGroupeEmploye(int id, GroupeEmploye groupe)
        {
            try
            {
                if (id!=groupe.Id)
                {
                    return BadRequest("Id de groupe ne correspond pas");
                }
                var gToUpdate = await _groupeEmployeRepository.GetGroupeEmploye(id);
                if (gToUpdate == null)
                    return NotFound($"GroupeEmploye avec Id={id} n'a pas été trouvé");
                return await _groupeEmployeRepository.UpdateGroupeEmploye(groupe);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Erreur execption non capturée de database, cela peut être une erreur de connexion");
            }
        }
        #endregion
        #region Supprimer un groupe
        [HttpDelete("{id:int")]
        public async Task<ActionResult<GroupeEmploye>> DeleteGroupeEmploye(int id)
        {
            try
            {
                var gToDelete = await _groupeEmployeRepository.GetGroupeEmploye(id);
                if (gToDelete==null)
                {
                    return NotFound($"GroupeEmploye avec Id={id} n'a pas été trouvé");
                }
                return await _groupeEmployeRepository.DeleteGroupeEmploye(id);
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
