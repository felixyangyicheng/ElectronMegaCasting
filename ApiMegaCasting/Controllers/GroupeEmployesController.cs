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
    }
}
