using Application;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class BorrowOrderController : BaseController
    {
        private IMapper mapper;
        private IDispatcher dispatcher;

        public BorrowOrderController(IMapper mapper, IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            this.mapper = mapper;
        }

        // GET: api/<BorrowOrderController>
        [HttpGet]
        [Route("BorrowOrder")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BorrowOrderController>/5
        //[HttpGet("{OrderId}")]
        [HttpGet]
        [Route("BorrowOrder/{OrderId}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BorrowOrderController>
        [HttpPost]
        [Route("BorrowOrder")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BorrowOrderController>/5
        //[HttpPut("{OrderId}")]
        [HttpPut]
        [Route("BorrowOrder/{OrderId}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BorrowOrderController>/5
        //[HttpDelete("{OrderId}")]
        [HttpDelete]
        [Route("BorrowOrder/{OrderId}")]
        public void Delete(int id)
        {
        }
    }
}
