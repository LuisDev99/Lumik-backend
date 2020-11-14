using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.API.Models;
using Assistant.Core.Entities;
using Assistant.Core.Enums;
using Assistant.Core.Interfaces;
using Assistant.Core.Services;
using Assistant.Infraestructure;
using Microsoft.AspNetCore.Mvc;


namespace Assistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/<EventsController>
        [HttpGet]
        public ActionResult<IEnumerable<EventDTO>> Get()
        {
            var events = _eventService.Get();

            if(events.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(events.Error);
            }
            
            return Ok(events.Result.Select(
                _event => new EventDTO
                {
                    ID = _event.ID,
                    Title = _event.Title,
                    TriggerDate = _event.TriggerDate,
                    UserID = _event.UserID
                }    
            ));
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult<EventDTO> Get(int id)
        {
            var _event = _eventService.GetByID(id);

            if(_event.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_event.Error);
            }

            return Ok(new EventDTO
            {
                ID = _event.Result.ID,
                Title = _event.Result.Title,
                TriggerDate = _event.Result.TriggerDate,
                UserID = _event.Result.UserID
            });            
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
            _eventService.Delete(new Event { ID = id }); 
        }
    }
}
