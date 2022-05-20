using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibUserController : BaseController
    {
        // GET: api/<LibUserController>
        [HttpGet]
        [Route("LibUser")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LibUserController>/5
        [HttpGet]
        [Route("LibUser/{SSN}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LibUserController>
        [HttpPost]
        [Route("LibUser")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LibUserController>/5
        [HttpPut]
        [Route("LibUser/{SSN}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibUserController>/5
        [HttpDelete]
        [Route("LibUser/{SSN}")]
        public void Delete(int id)
        {
        }
    }
}
