using ApiMegaCasting.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMegaCasting.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class ProfessionSectorsController : ControllerBase
    //{

    //    private readonly IProfessionSectorRepository _professionSectorRepository;
    //    public ProfessionSectorsController(IProfessionSectorRepository professionSectorRepository)
    //    {
    //        this._professionSectorRepository = professionSectorRepository;
    //    }

    //    // GET: api/<ProfessionSectorsController>
    //    [HttpGet]
    //    public async Task<ActionResult> GetProfessionSectors()
    //    {
    //        try
    //        {
    //            return Ok(await _professionSectorRepository.GetProfessionSectors());
    //        }
    //        catch (Exception)
    //        {

    //            return StatusCode(StatusCodes.Status500InternalServerError,
    //                "Erreur de recherche depuis la base de données");
    //        }
    //    }

        //// GET api/<ProfessionSectorsController>/5
        //[HttpGet("{id:int}")]


        //// POST api/<ProfessionSectorsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}







        //// PUT api/<ProfessionSectorsController>/5
        //[HttpPut("{id}")]


        //// DELETE api/<ProfessionSectorsController>/5
        //[HttpDelete("{id}")]

    //}
}
