using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMegaCasting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionSectorsController : ControllerBase
    {



        // GET: api/<ProfessionSectorsController>
        [HttpGet]
       

        // GET api/<ProfessionSectorsController>/5
        [HttpGet("{id:int}")]
        

        // POST api/<ProfessionSectorsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }







        // PUT api/<ProfessionSectorsController>/5
        [HttpPut("{id}")]
      

        // DELETE api/<ProfessionSectorsController>/5
        [HttpDelete("{id}")]
       
    }
}
