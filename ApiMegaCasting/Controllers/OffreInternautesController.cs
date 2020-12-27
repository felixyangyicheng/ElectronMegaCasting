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
    public class OffreInternautesController : ControllerBase
    {
        private readonly IOffreInternauteRepository _offreInternauteRepository;
        public OffreInternautesController(IOffreInternauteRepository offreInternauteRepository)
        {
            this._offreInternauteRepository = offreInternauteRepository;
        }

        #region Liste des Offre-internaute
        [HttpGet]
        public  async Task<ActionResult> GetOffreInternautes()
        {
            try
            {
                return Ok(await _offreInternauteRepository.GetOffresInternautes());
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
