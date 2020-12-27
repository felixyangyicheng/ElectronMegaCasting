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
    public class CivilitesController : ControllerBase
    {
        private readonly ICiviliteRepository _civiliteRepository;

        public CivilitesController(ICiviliteRepository civiliteRepository)
        {
            this._civiliteRepository = civiliteRepository;
        }


        #region liste de tous les civilités
        [HttpGet]
        public async Task<ActionResult> GetCivilites()
        {
            try
            {
                return Ok(await _civiliteRepository.GetCivilites());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erreur execption non capturée de database");
            }
        }
        #endregion

        #region Civilité par id
        [HttpGet("{id:int}")]

        public async Task<ActionResult<Civilite>> GetCivilite(int id)
        {
            try
            {
                var result = await _civiliteRepository.GetCivilite(id);
                if (result==null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Erreur execption non capturée de database");
            }
        }
        #endregion

    }
}
