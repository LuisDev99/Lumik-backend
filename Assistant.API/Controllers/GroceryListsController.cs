using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryListsController : ControllerBase
    {
        // GET: api/<GroceryListsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GroceryListsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GroceryListsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GroceryListsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GroceryListsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
