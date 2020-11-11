using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Infraestructure;
using Microsoft.AspNetCore.Mvc;


namespace Assistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AssistantDbContext _dbContext;

        public EventsController(AssistantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _dbContext.Events.Add(new Core.Entities.Event{ Title="OK", UserID=0, TriggerDate=new DateTime()});
            _dbContext.SaveChanges();

            return new string[] { "value1", "value2" };
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
