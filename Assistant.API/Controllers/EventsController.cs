using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.API.Models;
using Assistant.API.Models.InsertModels;
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
        public ActionResult<EventDTO> Post([FromBody] AddEvent value)
        {
            var _event = _eventService.Insert(new Event
            {
                Title = value.Title,
                UserID = value.UserID,
                TriggerDate = value.TriggerDate,                 
            });

            if(_event.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_event.Error);
            }

            return Ok(new EventDTO
            {
                ID = _event.Result.ID,
                Title = _event.Result.Title,
                TriggerDate = _event.Result.TriggerDate,
                UserID = _event.Result.UserID,
            });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public ActionResult<EventDTO> Put(int id, [FromBody] AddEvent value)
        {
            var _event = _eventService.Update(new Event
            {
                ID = id,
                Title = value.Title,
                UserID = value.UserID,
                TriggerDate = value.TriggerDate,
            });

            if(_event.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_event.Error);
            }

            return Ok(new EventDTO
            {
                ID = id,
                Title = value.Title,
                UserID = value.UserID,
                TriggerDate = value.TriggerDate,
            });
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public ActionResult<EventDTO> Delete(int id)
        {
            var _event = _eventService.Delete(new Event { ID = id });

            if (_event.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(_event.Error);
            }

            if (_event.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(_event.Error);
            }

            return Ok(new EventDTO {
                ID = _event.Result.ID,
                Title = _event.Result.Title,
                UserID = _event.Result.UserID,
                TriggerDate = _event.Result.TriggerDate
            });

        }
    }
}
